using System.Data.SqlClient;

namespace DateManagementMySQL.Core.Interface.DataContext
{
    public interface IDataContext
    {
        SqlConnection GetConnection();
        SqlCommand CreateCommand();
    }
}
