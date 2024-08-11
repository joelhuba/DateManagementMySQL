using DateManagementMySQL.Core.DTOS.Common;

namespace DateManagementMySQL.Core.Interface.BLL
{
    public interface IAuthBLL
    {
        public Task<ResponseDTO> Auth(string username, string password);
    }
}
