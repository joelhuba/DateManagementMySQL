using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Respository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Core.Interfaces.BLL;
using DateManagementMySQL.Infrastructure.Extensions;
using System.Reflection;

namespace DateManagementMySQL.Infrastructure.BLL
{
    public class EpsBLL(IepsRepository epsRepository, IlogService logService) : IEpsBLL
    {
        private readonly IlogService _logService = logService;
        private readonly IepsRepository _epsRepository = epsRepository;
        public async Task<ResponseDTO> CreateEps(EpsDTO epsDTO)
        {
            try
            {
                return await _epsRepository.CreateEps(epsDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> DeleteEps(int IdEps)
        {
            try
            {
                return await _epsRepository.DeleteEps(IdEps);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListEps(PaginatorDTO paginator, string? epsName)
        {
            try
            {
                return await _epsRepository.GetListEps(paginator, epsName);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }


        public async Task<ResponseDTO> UpdateEps(EpsDTO epsDTO)
        {
            try
            {
                return await _epsRepository.UpdateEps(epsDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
