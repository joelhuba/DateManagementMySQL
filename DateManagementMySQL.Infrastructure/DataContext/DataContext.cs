using DateManagementMySQL.Core.Interface.DataContext;
using DateManagementMySQL.Core.Interface.Service;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DateManagementMySQL.Infrastructure.DataContext
{
    public class DataContext(IlogService logService, IConfiguration configuration) : IDisposable, IDataContext
    {
        private readonly IlogService _logService = logService;
        private readonly IConfiguration _configuration = configuration;
        private MySqlConnection? connection;
        public MySqlConnection GetConnection()
        {
            try
            {
                if (connection == null || connection.State == ConnectionState.Closed)
                {
                    string defaultConnection = _configuration.GetConnectionString("DefaultConnection") ?? "";
                    connection = new MySqlConnection(defaultConnection);
                    connection.Open();
                }
                return connection;
            }
            catch (Exception ex)
            {
                _logService.message($"Error :: {ex}");
                throw;
            }
        }
        public MySqlCommand CreateCommand()
        {
            try
            {
                var command = new MySqlCommand();
                command.Connection = GetConnection();
                command.CommandType = CommandType.Text;
                return command;
            }
            catch (Exception ex)
            {
                _logService.message($"Error :: {ex}");
                throw;
            }
        }

        public void Dispose()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }


    }
}
