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
    public class AwsServiceController(IAwsServiceBLL awsService, IlogService logService) : ControllerBase
    {
        private readonly IAwsServiceBLL _awsService = awsService;
        private readonly IlogService _logService = logService;

        [HttpPost]
        [Route("/DateManagement/UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile file) => await HandleResponses.HandleResponse(() => _awsService.UploadFileAsync(file), _logService, MethodBase.GetCurrentMethod().Name);
        [HttpDelete]
        [Route("/DateManagement/DeleteImage")]
        public async Task<IActionResult> DeleteImage(string fileName,int fileId) => await HandleResponses.HandleResponse(() => _awsService.DeleteFileAsync(fileName, fileId), _logService, MethodBase.GetCurrentMethod().Name);
        [HttpGet]
        [Route("/DateManagement/GetUrlImage")]
        public async Task<IActionResult> GetUrlImage(string fileName) => await HandleResponses.HandleResponse(() => _awsService.GetUrlFileAsync(fileName), _logService, MethodBase.GetCurrentMethod().Name);
    }
}
