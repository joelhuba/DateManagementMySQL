using MySql.Data.MySqlClient;

namespace DateManagementMySQL.Core.Interface.DataContext
{
    public interface IDataContext
    {
        MySqlConnection GetConnection();
        MySqlCommand CreateCommand();
    }
}
