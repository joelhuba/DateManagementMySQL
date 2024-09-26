using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using DateManagementMySQL.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DateManagementMySQL.Infrastructure.BLL.Service
{
    public class AwsServiceBLL(IAwsService awsService,IlogService logService) : IAwsServiceBLL
    {
        private readonly IAwsService _awsService = awsService;
        private readonly IlogService _logService = logService;

        public async Task<ResponseDTO> DeleteFileAsync(string fileName, int fileId)
        {
            try
            {
                return await _awsService.DeleteFileAsync(fileName, fileId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetUrlFileAsync(string fileName)
        {
            try
            {
                return await _awsService.GetUrlFileAsync(fileName);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UploadFileAsync(IFormFile fileData)
        {
            try
            {
                return await _awsService.UploadFileAsync(fileData);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
