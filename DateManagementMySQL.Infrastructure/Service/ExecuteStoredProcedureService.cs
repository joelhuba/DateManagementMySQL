﻿using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.DataContext;
using DateManagementMySQL.Core.Interface.Service;
using MySql.Data.MySqlClient;
using System.Data;

namespace DateManagementMySQL.Infrastructure.Services
{
    public class ExecuteStoredProcedureService : IExecuteStoredProcedureService
    {
        private readonly IDataContext _context;
        private readonly IlogService _logService;
        private readonly ISqlCommandService _sqlCommandService;

        public ExecuteStoredProcedureService(IDataContext context, IlogService logService, ISqlCommandService sqlCommandService)
        {
            _context = context;
            _logService = logService;
            _sqlCommandService = sqlCommandService;
        }

        private void HandleException(Exception ex, string storedProcedureName, ResponseDTO response)
        {
            _logService.message($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
            response.Message += ex.ToString();
        }

        public async Task<ResponseDTO> ExecuteStoredProcedure(string storedProcedureName, object parameters)
        {
            ResponseDTO response = new ResponseDTO();
            response.IsSuccess = false;
            try
            {
                using MySqlCommand command = _context.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                _sqlCommandService.AddParameters(command, parameters);
                using var reader = await command.ExecuteReaderAsync();
                reader.ReadAsync();
                response.Message = reader.GetString(reader.GetOrdinal("Message"));
                response.IsSuccess = reader.GetBoolean(reader.GetOrdinal("IsSuccess"));
            }
            catch (Exception ex)
            {
                _logService.message($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
            }
            return response;
        }

        public async Task<ResponseDTO> ExecuteDataStoredProcedure<TResult>(string storedProcedureName, object parameters, Func<MySqlDataReader, List<TResult>> mapFunction)
        {
            ResponseDTO response = new ResponseDTO();
            response.IsSuccess = false;
            try
            {
                using MySqlCommand command = _context.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                _sqlCommandService.AddParameters(command, parameters);
                using var reader = await command.ExecuteReaderAsync();
                List<TResult> resultList = mapFunction((MySqlDataReader)reader);
                response.Data = resultList;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logService.message($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
                response.Message += ex.ToString();
            }
            return response;
        }

        public async Task<ResponseDTO> ExecuteSingleObjectStoredProcedure<TResult>(string storedProcedureName, object parameters, Func<MySqlDataReader, TResult> mapFunction)
        {
            ResponseDTO response = new ResponseDTO();
            response.IsSuccess = false;
            try
            {
                using MySqlCommand command = _context.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                _sqlCommandService.AddParameters(command, parameters);
                using var reader = await command.ExecuteReaderAsync();
                TResult resultList = mapFunction((MySqlDataReader)reader);
                response.Data = resultList;
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logService.message($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
                response.Message += ex.ToString();
            }
            return response;
        }

        public async Task<ResponseDTO> ExecuteJSONStoredProcedure(string storedProcedureName, object parameters)
        {
            ResponseDTO response = new ResponseDTO();
            response.IsSuccess = false;
            try
            {
                using MySqlCommand command = _context.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                _sqlCommandService.AddParameters(command, parameters);

                using var reader = await command.ExecuteReaderAsync();

                bool hasErrorMessageColumn = reader.FieldCount > 0 && Enumerable.Range(0, reader.FieldCount).Any(i => reader.GetName(i) == "ErrorMessage");

                if (await reader.ReadAsync() && hasErrorMessageColumn)
                {
                    var errorMessage = reader["ErrorMessage"].ToString();
                    if (errorMessage == "No Access")
                    {
                        response.Message = "No tienes permisos para realizar esta operación.";
                        return response;
                    }
                }

                if (!reader.IsClosed && reader.HasRows)
                {
                    reader.Close();
                    using var readerAgain = await command.ExecuteReaderAsync();
                    if (readerAgain.HasRows && await readerAgain.ReadAsync())
                    {
                        if (!readerAgain.IsDBNull(readerAgain.GetOrdinal("JSONString")))
                        {
                            var dataResponse = readerAgain.GetString(readerAgain.GetOrdinal("JSONString"));
                            response.Data = dataResponse ?? null;
                            response.IsSuccess = true;
                        }
                        else
                        {
                            response.Message = "No se encontraron datos.";
                        }
                    }
                    else
                    {
                        response.Message = "No se encontraron datos.";
                    }
                }
            }
            catch (Exception ex)
            {
                _logService.message($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
                response.Message += ex.ToString();
            }
            return response;
        }



        public async Task<ResponseDTO> ExecuteTableStoredProcedure<TResult>(string storedProcedureName, object? parameters, Func<MySqlDataReader, List<TResult>> mapFunction)
        {
            var response = new ResponseDTO
            {
                IsSuccess = false
            };

            try
            {
                using var command = _context.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    _sqlCommandService.AddParameters(command, parameters);
                }

                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync() && reader.FieldCount == 1 && reader.GetValue(0).ToString() == "No Access")
                {
                    response.Message = "No tienes permisos para realizar esta operación.";
                    return response;
                }
                else
                {
                    reader.Close();
                    using var readerAgain = await command.ExecuteReaderAsync();
                    var resultList = mapFunction((MySqlDataReader)readerAgain);
                    int totalRecords = 0;

                    if (await readerAgain.NextResultAsync() && await readerAgain.ReadAsync())
                    {
                        totalRecords = readerAgain.GetInt32(readerAgain.GetOrdinal("TotalRecords"));
                    }

                    response.Data = new { Results = resultList, TotalRecords = totalRecords };
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, storedProcedureName, response);
            }

            return response;
        }
    }
}
