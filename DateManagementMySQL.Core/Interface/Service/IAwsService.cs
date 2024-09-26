using DateManagementMySQL.Core.DTOS.Common;
using Microsoft.AspNetCore.Http;

namespace DateManagementMySQL.Core.Interface.Service
{
    public interface IAwsService
    {
        public  Task<ResponseDTO> UploadFileAsync( IFormFile fileData);
        public Task<ResponseDTO> DeleteFileAsync(string fileName, int fileId);
        public Task<ResponseDTO> GetUrlFileAsync(string fileName);
    }
}
