using DateManagementMySQL.Core.Interface.Service;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace Portafolio.Infrastructure.Services
{
    public class SqlCommandServices : ISqlCommandService
    {
        public void AddParameters<T>(MySqlCommand command, T parameters)
        {
            if (parameters != null)
            {
                PropertyInfo[] properties = parameters.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    string parameterName = $"P_{property.Name}";
                    object? value = property.GetValue(parameters);

                    command.Parameters.AddWithValue(parameterName, value ?? DBNull.Value);
                }
            }
        }
    }
}
