using MySql.Data.MySqlClient;

namespace DateManagementMySQL.Core.Interface.Service
{
    public interface ISqlCommandService
    {
        void AddParameters<T>(MySqlCommand command, T parameters);
    }
}
