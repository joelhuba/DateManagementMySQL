using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;

namespace DateManagementMySQL.Core.Interface.Respository
{
    public interface IRolesRepository
    {
        public Task<ResponseDTO> CreateRol(RolesDTO roles);
        public Task<ResponseDTO> UpdateRol(RolesDTO roles);
        public Task<ResponseDTO> DeleteRol(int Idrol);
        public Task<ResponseDTO> GetAllRoles(PaginatorDTO paginator);
        public Task<ResponseDTO> GetRolesById(int idRol);
    }
}
