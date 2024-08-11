using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Respository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;

namespace Portafolio.Infrastructure.Repository
{
    public class RolesRepository(IExecuteStoredProcedureService executeStoredProcedure) : IRolesRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedure;
        public async Task<ResponseDTO> CreateRol(RolesDTO roles)
        {
            object obj = new
            {
                roles.Description
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("CreateRol", obj);
        }

        public async Task<ResponseDTO> DeleteRol(int idRol)
        {
            object obj = new
            {
                IdRol = idRol
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("DelRol", obj);

        }

        public async Task<ResponseDTO> GetAllRoles(PaginatorDTO paginator)
        {
            object obj = new
            {
                paginator.PageIndex,
                paginator.PageSize
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure<RolesDTO>("GetAllRoles", obj, MapToListHelper.MapToList<RolesDTO>);

        }

        public async Task<ResponseDTO> GetRolesById(int idRol)
        {

            object obj = new
            {
                IdRol = idRol
            };
            return await _executeStoredProcedureService.ExecuteSingleObjectStoredProcedure<RolesDTO>("GetRolesById", obj, MapToObjHelper.MapToObj<RolesDTO>);
        }

        public async Task<ResponseDTO> UpdateRol(RolesDTO roles)
        {
            object obj = new
            {
                roles.IdRol,
                roles.Description
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdateRol", obj);
        }
    }
}
