using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using System.Reflection;

namespace DateManagementMySQL.Infrastructure.BLL
{
    public class ImageAwsBLL(IAwsImagesRepository awsImagesRepository,IlogService logService) : IAwsImageBLL
    {
        private readonly IAwsImagesRepository _awsImagesRepository = awsImagesRepository;
        private readonly IlogService _logService = logService;
        public async Task<ResponseDTO> DeleteImage(int fileId)
        {
            try
            {
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

        public async Task<ResponseDTO> UpdateImage(AwsImagesDTO awsImagesDTO)
        {

            try
            {
                return await _awsImagesRepository.UpdateImage(awsImagesDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UploadImage(AwsImagesDTO awsImagesDTO)
        {
            try
            {
                return await _awsImagesRepository.UploadImage(awsImagesDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
