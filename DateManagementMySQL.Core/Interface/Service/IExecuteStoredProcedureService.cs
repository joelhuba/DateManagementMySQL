using DateManagementMySQL.Core.DTOS.Common;
using MySql.Data.MySqlClient;

namespace DateManagementMySQL.Core.Interface.Service
{
    public interface IExecuteStoredProcedureService
    {
        Task<ResponseDTO> ExecuteStoredProcedure(string storedProcedureName, object parameters);
        Task<ResponseDTO> ExecuteJSONStoredProcedure(string storedProcedureName, object parameters);
        Task<ResponseDTO> ExecuteDataStoredProcedure<TResult>(string storedProcedureName, object? parameters, Func<MySqlDataReader, List<TResult>> mapFunction);
        Task<ResponseDTO> ExecuteTableStoredProcedure<TResult>(string storedProcedureName, object? parameters, Func<MySqlDataReader, List<TResult>> mapFunction);
        Task<ResponseDTO> ExecuteSingleObjectStoredProcedure<TResult>(string storedProcedureName, object? parameters, Func<MySqlDataReader, TResult> mapFunction);


    }
}
