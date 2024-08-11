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
    public class AuthController(IAuthBLL authBLL,IlogService logService) : ControllerBase
    {
        private readonly IAuthBLL _authBLL = authBLL;
        private readonly IlogService _logService = logService;
        [HttpPost("/Auth")]
        public async Task<IActionResult> Auth(string username, string password)
        => await HandleResponses.HandleResponse(()=>_authBLL.Auth(username, password),_logService,MethodBase.GetCurrentMethod().Name);
    }
}
