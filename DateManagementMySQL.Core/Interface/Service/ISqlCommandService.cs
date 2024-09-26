using System.Data.SqlClient;

namespace DateManagementMySQL.Core.Interface.Service
{
    public interface ISqlCommandService
    {
        void AddParameters<T>(SqlCommand command, T parameters);
    }
}
