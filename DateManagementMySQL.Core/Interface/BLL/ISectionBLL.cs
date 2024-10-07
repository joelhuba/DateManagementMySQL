using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateManagementMySQL.Core.Interface.BLL
{
    public interface ISectionBLL
    {
        Task<ResponseDTO> CreateSection(SectionDTO sectionDTO);
        Task<ResponseDTO> UpdateSection(SectionDTO sectionDTO);
        Task<ResponseDTO> DeleteSection(int sectionId);
        Task<ResponseDTO> GetListSection(PaginatorDTO paginatorDTO, int? sectionId);
    }
}
