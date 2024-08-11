using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Core.Interfaces.BLL;
using DateManagementMySQL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DateManagementMySQL.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EpsController(IEpsBLL epsBLL, IlogService logService) : ControllerBase
    {
        IEpsBLL _epsBll = epsBLL;
        IlogService _logService = logService;

        [HttpPost("/DateManagement/CreateEps")]
        public async Task<IActionResult> CreateEps(EpsDTO epsDTO)
        => await HandleResponses.HandleResponse(() =>_epsBll.CreateEps(epsDTO),_logService,MethodBase.GetCurrentMethod().Name);


        [HttpPut("/DateManagement/UpdateEps")]
        public async Task<IActionResult> UpdateEps(EpsDTO epsDTO)
        => await HandleResponses.HandleResponse(() => _epsBll.UpdateEps(epsDTO), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpDelete("/DateManagement/DeleteEps")]
        public async Task<IActionResult> DeleteEps(int idEps)
        => await HandleResponses.HandleResponse(() => _epsBll.DeleteEps(idEps), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/DateManagement/GetEps")]
        public async Task<IActionResult> GetEps([FromQuery]PaginatorDTO paginator)
        => await HandleResponses.HandleResponse(() => _epsBll.GetAllEps(paginator), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/DateManagement/GetEpsById")]
        public async Task<IActionResult> GetEpsById([FromQuery] int idEps)
        => await HandleResponses.HandleResponse(() => _epsBll.GetEpsById(idEps), _logService, MethodBase.GetCurrentMethod().Name);

    }
}
