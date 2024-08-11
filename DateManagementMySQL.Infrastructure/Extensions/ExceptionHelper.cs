using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Service;

namespace DateManagementMySQL.Infrastructure.Extensions
{
    public static class ExceptionHelper
    {
        public static ResponseDTO HandleException(IlogService logService, string methodName, Exception ex)
        {
            logService.message($"Se ha producido un error al ejecutar BLL: {methodName}: {ex.Message}");
            var response = new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
            return response;
        }
    }
}
