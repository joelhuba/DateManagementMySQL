using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;

namespace DateManagementMySQL.Core.Interfaces.BLL
{
    public interface IEpsBLL
    {
        public Task<ResponseDTO> CreateEps(EpsDTO epsDTO);
        public Task<ResponseDTO> UpdateEps(EpsDTO epsDTO);
        public Task<ResponseDTO> DeleteEps(int IdEps);
        public Task<ResponseDTO> GetListEps(PaginatorDTO paginator,string? epsName);
    }
}
