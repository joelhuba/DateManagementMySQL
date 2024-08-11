using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;

namespace DateManagementMySQL.Infrastructure.Repository
{
    public class AuthRepository(IExecuteStoredProcedureService executeStoredProcedure) : IAuthUserRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedure;
        public async Task<ResponseDTO> Auth(string username)
        {
            object obj = new
            {
                Username = username
            };
            return await _executeStoredProcedureService.ExecuteSingleObjectStoredProcedure("Auth", obj, MapToObjHelper.MapToObj<AuthUserDTO>);
        }
    }
}
