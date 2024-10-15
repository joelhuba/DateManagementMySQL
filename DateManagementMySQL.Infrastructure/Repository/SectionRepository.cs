using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using DateManagementMySQL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateManagementMySQL.Infrastructure.Repository
{
    public class SectionRepository(IExecuteStoredProcedureService executeStoredProcedureService) : ISectionRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedureService;
        public async Task<ResponseDTO> CreateSection(SectionDTO sectionDTO)
        {
            object obj = new
            {
                sectionDTO.SectionName,
                sectionDTO.SectionContent,
                sectionDTO.Image,
                sectionDTO.ImageName,
                sectionDTO.IsActive

            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("CreateSection", obj);
        }

        public async Task<ResponseDTO> DeleteSection(int sectionId)
        {
            object obj = new
            {
                SectionId =sectionId 
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("DeleteSection", obj);
        }

        public async Task<ResponseDTO> GetListSection(PaginatorDTO paginatorDTO, int? sectionId)
        {
            object obj = new
            {
                paginatorDTO.PageIndex,
                paginatorDTO.PageSize,
                SectionId = sectionId
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure("GetListSection", obj, MapToListHelper.MapToList<SectionDTO>);
        }

        public async Task<ResponseDTO> UpdateSection(SectionDTO sectionDTO)
        {
            object obj = new
            {
                sectionDTO.SectionId,
                sectionDTO.SectionName,
                sectionDTO.SectionContent,
                sectionDTO.Image,
                sectionDTO.ImageName,
                sectionDTO.IsActive

            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdateSection", obj);
        }
    }
}
