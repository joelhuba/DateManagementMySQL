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
    public class RolesController(IRolesBLL rolesBLL,IlogService logService) : ControllerBase
    {
        IRolesBLL _rolesBll = rolesBLL;
        IlogService _logService = logService;

        [HttpPost("/DateManagement/CreateRol")]
        public async Task<IActionResult> CreateRol(RolesDTO roleDTO) 
        => await HandleResponses.HandleResponse(()=>_rolesBll.CreateRol(roleDTO),_logService,MethodBase.GetCurrentMethod().Name);

        [HttpPut("/DateManagement/UpdateRol")]
        public async Task<IActionResult> UpdateRol(RolesDTO roleDTO) 
        => await HandleResponses.HandleResponse(() => _rolesBll.UpdateRol(roleDTO), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpDelete("/DateManagement/DeleteRol")]
        public async Task<IActionResult> DeleteRol(int idRol)
         => await HandleResponses.HandleResponse(() => _rolesBll.DeleteRol(idRol), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/DateManagement/GetListRoles")]
        public async Task<IActionResult> GetListRoles([FromQuery]PaginatorDTO paginatorDTO,string? description)
        => await HandleResponses.HandleResponse(() => _rolesBll.GetListRoles(paginatorDTO, description), _logService, MethodBase.GetCurrentMethod().Name);

    }
}
