using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Respository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;

namespace Portafolio.Infrastructure.Repository
{
    public class EpsRepository(IExecuteStoredProcedureService executeStoredProcedureService) : IepsRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedureService;

        public async Task<ResponseDTO> DeleteEps(int idEps)
        {
            object obj = new
            {
                IdEps = idEps
            };

          return await  _executeStoredProcedureService.ExecuteStoredProcedure("DelEps", obj);
        }

      
        public async Task<ResponseDTO> CreateEps(EpsDTO epsDTO)
        {
            object obj = new
            {
                epsDTO.EpsName
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("CreateEps", obj);
        }

        public async Task<ResponseDTO> UpdateEps(EpsDTO epsDTO)
        {
            object obj = new
            {
                epsDTO.IdEps,
                epsDTO.EpsName
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdateEps", obj);
        }

        public async Task<ResponseDTO> GetListEps(PaginatorDTO paginator, string? epsName)
        {
            object obj = new
            {
                paginator.PageIndex,
                paginator.PageSize,
                EpsName = epsName
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure("GetListEps", obj, MapToListHelper.MapToList<EpsDTO>);
        }
    }
}
