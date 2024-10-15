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
    public class ImageAwsBLL(IAwsImagesRepository awsImagesRepository,IlogService logService,IAwsService awsService) : IAwsImageBLL
    {
        private readonly IAwsImagesRepository _awsImagesRepository = awsImagesRepository;
        private readonly IlogService _logService = logService;
        private readonly IAwsService _awsService = awsService;
        public async Task<ResponseDTO> DeleteImage(int fileId,string fileName)
        {
            try
            {
                await _awsService.DeleteFileAsync(fileName);
                return await _awsImagesRepository.DeleteImage(fileId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListImages(PaginatorDTO paginatorDTO, int? fileId)
        {
            try
            {
                return await _awsImagesRepository.GetListImages(paginatorDTO, fileId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdateImage(AwsImagesDTO awsImagesDTO,IFormFile fileData)
        {
            try
            {

                await _awsService.DeleteFileAsync(awsImagesDTO.FileName);
                var upload = await _awsService.UploadFileAsync(fileData);
                var uploadedImage = upload.Data as AwsImagesDTO;
                awsImagesDTO.FileUrl = uploadedImage.FileUrl;
                return await _awsImagesRepository.UpdateImage(awsImagesDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UploadImage(IFormFile fileData)
        {
            try
            {
                var data = await _awsService.UploadFileAsync(fileData);
                var awsData = data.Data as AwsImagesDTO;
                return await _awsImagesRepository.UploadImage(awsData);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
