using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DateManagementMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController(ISectionBLL sectionBLL,IlogService logService) : ControllerBase
    {
        private readonly ISectionBLL _sectionBLL = sectionBLL;
        private readonly IlogService _logService = logService;

        [HttpPost("/DateManagement/CreateSection")]
        public async Task<IActionResult> CreateSection(SectionDTO sectionDTO)
        => await HandleResponses.HandleResponse(() => _sectionBLL.CreateSection(sectionDTO), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpPut("/DateManagement/UpdateSection")]
        public async Task<IActionResult> UpdateSection(SectionDTO sectionDTO)
        => await HandleResponses.HandleResponse(() => _sectionBLL.UpdateSection(sectionDTO), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpDelete("/DateManagement/DeleteSection")]
        public async Task<IActionResult> DeleteSection(int sectionId)
        => await HandleResponses.HandleResponse(() => _sectionBLL.DeleteSection(sectionId), _logService, MethodBase.GetCurrentMethod().Name);


        [HttpGet("/DateManagement/GetListSection")]
        public async Task<IActionResult> GetListSection([FromQuery]PaginatorDTO paginator,int? sectionId)
        => await HandleResponses.HandleResponse(() => _sectionBLL.GetListSection(paginator, sectionId), _logService, MethodBase.GetCurrentMethod().Name);

    }
}
