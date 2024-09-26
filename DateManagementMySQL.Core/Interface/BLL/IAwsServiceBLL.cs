using DateManagementMySQL.Core.DTOS.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateManagementMySQL.Core.Interface.BLL
{
    public interface IAwsServiceBLL
    {
        public Task<ResponseDTO> UploadFileAsync(IFormFile fileData);
        public Task<ResponseDTO> DeleteFileAsync(string fileName, int fileId);
        public Task<ResponseDTO> GetUrlFileAsync(string fileName);
    }
}
