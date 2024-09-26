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
    public class AwsImageController(IAwsImageBLL awsImageBLL,IlogService ilogService ) : ControllerBase
    {
        private readonly IAwsImageBLL _awsImageBLL = awsImageBLL;
        private readonly IlogService _logService = ilogService;

        [HttpPut]
        [Route("/DateManagement/UpdateData")]
        public async Task<IActionResult> UpdateData(AwsImagesDTO awsImagesDTO)
        => await HandleResponses.HandleResponse(() => _awsImageBLL.UpdateImage(awsImagesDTO),_logService,MethodBase.GetCurrentMethod().Name);
        [HttpGet]
        [Route("/DateManagement/GetListImages")]
        public async Task<IActionResult> GetListImages([FromQuery]PaginatorDTO paginator,int fileId)
        => await HandleResponses.HandleResponse(() => _awsImageBLL.GetListImages(paginator, fileId), _logService, MethodBase.GetCurrentMethod().Name);
    }
}
