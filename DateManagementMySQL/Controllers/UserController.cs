using DateManagementMySQL.Helpers;
using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Core.Interfaces.BLL;
using DateManagementMySQL.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;

namespace DateManagementMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserBLL userBLL,IlogService ilogService) : ControllerBase
    {
        IUserBLL _userBLL = userBLL;
        IlogService _logService = ilogService;

        [HttpPost("/DateManagement/CreateUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        => await HandleResponses.HandleResponse(()=>_userBLL.CreateUser(userDTO),_logService,MethodBase.GetCurrentMethod().Name);

        [HttpPut("/DateManagement/UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        => await HandleResponses.HandleResponse(() => _userBLL.UpdateUser(userDTO), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpDelete("/DateManagement/DeleteUser")]
        public async Task<IActionResult> DeleteUser(int idUser)
        => await HandleResponses.HandleResponse(() => _userBLL.DelUser(idUser), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/DateManagement/GetListUsers")]
        public async Task<IActionResult> GetListUsers([FromQuery]PaginatorDTO paginator,int? idUser)
        => await HandleResponses.HandleResponse(() => _userBLL.GetListUsers(paginator, idUser), _logService, MethodBase.GetCurrentMethod().Name);



    }
}
