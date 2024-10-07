using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using System.Reflection;
using static System.Collections.Specialized.BitVector32;

namespace DateManagementMySQL.Infrastructure.BLL
{
    public class SectionBLL(IlogService logService,ISectionRepository sectionRepository) : ISectionBLL
    {
        private ISectionRepository _sectionRepository = sectionRepository;
        private IlogService _logService = logService;
        public async Task<ResponseDTO> CreateSection(SectionDTO sectionDTO)
        {
            try
            {
                return await _sectionRepository.CreateSection(sectionDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService,MethodBase.GetCurrentMethod().Name ,ex);
            }
        }

        public async Task<ResponseDTO> DeleteSection(int sectionId)
        {
            try
            {
                return await _sectionRepository.DeleteSection(sectionId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListSection(PaginatorDTO paginatorDTO, int? sectionId)
        {
            try
            {
                return await _sectionRepository.GetListSection(paginatorDTO, sectionId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdateSection(SectionDTO sectionDTO)
        {
            try
            {
                return await _sectionRepository.UpdateSection(sectionDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
