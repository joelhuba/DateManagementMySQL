using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using DateManagementMySQL.Infrastructure.Services;

namespace DateManagementMySQL.Infrastructure.Repository
{
    public class AwsImagesRepository(IExecuteStoredProcedureService executeStoredProcedureService) : IAwsImagesRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedureService;
        public async Task<ResponseDTO> DeleteImage(int fileId)
        {
            object obj = new
            {
                FileId = fileId
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("DeleteImageAws", obj);
        }

        public async Task<ResponseDTO> GetListImages(PaginatorDTO paginatorDTO, int? fileId)
        {
            object obj = new
            {
                paginatorDTO.PageIndex,
                paginatorDTO.PageSize,
                FileId = fileId
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure("GetListImagesAws", obj, MapToListHelper.MapToList<AwsImagesDTO>);
        }

        public async Task<ResponseDTO> UpdateImage(AwsImagesDTO awsImagesDTO)
        {
            object obj = new
            {

                awsImagesDTO.FileId,
                awsImagesDTO.FileName,
                awsImagesDTO.ContentType,
                awsImagesDTO.FileUrl,
                awsImagesDTO.BucketName
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdateImageAws", obj);
        }

        public async Task<ResponseDTO> UploadImage(AwsImagesDTO awsImagesDTO)
        {
            object obj = new
            {

                awsImagesDTO.FileName,
                awsImagesDTO.ContentType,
                awsImagesDTO.FileUrl,
                awsImagesDTO.BucketName
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UploadImageAws", obj);
        }
    }
}
