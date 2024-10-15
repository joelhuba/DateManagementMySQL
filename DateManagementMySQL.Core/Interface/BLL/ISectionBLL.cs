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
    public interface ISectionBLL
    {
        Task<ResponseDTO> CreateSection(SectionDTO sectionDTO, IFormFile fileData);
        Task<ResponseDTO> UpdateSection(SectionDTO sectionDTO, IFormFile fileData);
        Task<ResponseDTO> DeleteSection(int sectionId);
        Task<ResponseDTO> GetListSection(PaginatorDTO paginatorDTO, int? sectionId);
    }
}
