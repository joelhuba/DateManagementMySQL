using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DateManagementMySQL.Core.Interface.BLL
{
    public interface IAwsImageBLL
    {
        public Task<ResponseDTO> UploadImage(IFormFile fileData);
        public Task<ResponseDTO> UpdateImage(AwsImagesDTO awsImagesDTO,IFormFile fileData);
        public Task<ResponseDTO> DeleteImage(int fileId, string fileName);
        public Task<ResponseDTO> GetListImages(PaginatorDTO paginatorDTO, int? fileId);
    }
}
