using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DateManagementMySQL.Helpers
{
    public class HandleResponses
    {
        public static async Task<ActionResult> HandleResponse(Func<Task<ResponseDTO>> action, IlogService _logService, string controllerName)
        {
            try
            {
                ResponseDTO response = await action.Invoke();

                return new OkObjectResult(response);

            }
            catch (ValidationException ex)
            {
                _logService.message($"Error desde :: {controllerName} :: {ex.Message}");
                return new BadRequestObjectResult(new ResponseDTO { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logService.message($"Error desde :: {controllerName} :: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
    }
}
