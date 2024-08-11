using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;

namespace DateManagementMySQL.Core.Interface.Respository
{
    public interface IepsRepository
    {
        public Task<ResponseDTO> CreateEps(EpsDTO epsDTO);
        public Task<ResponseDTO> UpdateEps(EpsDTO epsDTO);
        public Task<ResponseDTO> DeleteEps(int IdEps);
        public Task<ResponseDTO> GetEpsById(int IdEps);
        public Task<ResponseDTO> GetAllEps(PaginatorDTO paginator);
    }
}
