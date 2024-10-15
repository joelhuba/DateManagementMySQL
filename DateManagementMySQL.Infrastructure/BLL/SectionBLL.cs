using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace DateManagementMySQL.Infrastructure.BLL
{
    public class SectionBLL(IlogService logService,ISectionRepository sectionRepository,IAwsService awsService) : ISectionBLL
    {
        private ISectionRepository _sectionRepository = sectionRepository;
        private IlogService _logService = logService;
        private IAwsService _awsService = awsService;
        public async Task<ResponseDTO> CreateSection(SectionDTO sectionDTO, IFormFile fileData)
        {
            try
            {
                if(fileData != null)
                {
                    var upload = await _awsService.UploadFileAsync(fileData); 
                    var uploadedImage = upload.Data as AwsImagesDTO;
                    sectionDTO.Image = uploadedImage.FileUrl;
                    sectionDTO.ImageName = uploadedImage.FileName;
                    return await _sectionRepository.CreateSection(sectionDTO);
                }
                else
                {
                    return await _sectionRepository.CreateSection(sectionDTO);
                }        
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

        public async Task<ResponseDTO> UpdateSection(SectionDTO sectionDTO, IFormFile fileData)
        {
            try
            {
                if (fileData != null) {
                    await _awsService.DeleteFileAsync(sectionDTO.ImageName);
                    var upload = await _awsService.UploadFileAsync(fileData);
                    var uploadedImage = upload.Data as AwsImagesDTO;
                    sectionDTO.Image = uploadedImage.FileUrl;
                    sectionDTO.ImageName = uploadedImage.FileName;
                    return await _sectionRepository.UpdateSection(sectionDTO);
                }
                else
                {
                    return await _sectionRepository.UpdateSection(sectionDTO);
                }
               
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
