using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateManagementMySQL.Core.Interface.BLL
{
    public interface IAwsImageBLL
    {
        public Task<ResponseDTO> UploadImage(AwsImagesDTO awsImagesDTO);
        public Task<ResponseDTO> UpdateImage(AwsImagesDTO awsImagesDTO);
        public Task<ResponseDTO> DeleteImage(int fileId);
        public Task<ResponseDTO> GetListImages(PaginatorDTO paginatorDTO, int? fileId);
    }
}
