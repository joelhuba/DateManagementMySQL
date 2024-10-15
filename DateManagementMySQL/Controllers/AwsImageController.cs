using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Helpers;
using DateManagementMySQL.Infrastructure.Service;
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

        [HttpPost("/DateManagement/UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm]IFormFile fileData) => await HandleResponses.HandleResponse(()=>_awsImageBLL.UploadImage(fileData),_logService,MethodBase.GetCurrentMethod().Name);
        [HttpPut]
        [Route("/DateManagement/UpdateImage")]
        public async Task<IActionResult> UpdateData(AwsImagesDTO awsImagesDTO, IFormFile fileData)
        => await HandleResponses.HandleResponse(() => _awsImageBLL.UpdateImage(awsImagesDTO,fileData),_logService,MethodBase.GetCurrentMethod().Name);
        [HttpGet]
        [Route("/DateManagement/GetListImages")]
        public async Task<IActionResult> GetListImages([FromQuery]PaginatorDTO paginator,int fileId)
        => await HandleResponses.HandleResponse(() => _awsImageBLL.GetListImages(paginator, fileId), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpDelete]
        [Route("/DateManagement/DeleteImage")]
        public async Task<IActionResult> DeleteImage(string fileName, int fileId) => await HandleResponses.HandleResponse(() => _awsImageBLL.DeleteImage(fileId,fileName), _logService, MethodBase.GetCurrentMethod().Name);
    }
}
