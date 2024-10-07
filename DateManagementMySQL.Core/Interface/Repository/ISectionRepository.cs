using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;

namespace DateManagementMySQL.Core.Interface.Repository
{
    public interface ISectionRepository
    {
        Task<ResponseDTO> CreateSection(SectionDTO sectionDTO);
        Task<ResponseDTO> UpdateSection(SectionDTO sectionDTO);
        Task<ResponseDTO> DeleteSection(int sectionId);
        Task<ResponseDTO> GetListSection(PaginatorDTO paginatorDTO,int? sectionId);
    }
}
