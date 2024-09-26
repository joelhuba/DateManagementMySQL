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
    public class PatientReviewController(IPatientReviewBLL patientReviewBLL, IlogService logService) : ControllerBase
    {
        private readonly IPatientReviewBLL _patientReviewBLL =patientReviewBLL;
        private readonly IlogService _logService;

        [HttpPost("/DateManagement/CreateReview")]
        public async Task<IActionResult> CreateReview(PatientReviewDTO patientReview)
        => await HandleResponses.HandleResponse(() => _patientReviewBLL.CreatePatientReview(patientReview), _logService, MethodBase.GetCurrentMethod().Name);
        [HttpPut("/DateManagement/UpdateReview")]
        public async Task<IActionResult> UpdateReview(PatientReviewDTO patientReview)
        => await HandleResponses.HandleResponse(() => _patientReviewBLL.UpdatePatientReview(patientReview), _logService, MethodBase.GetCurrentMethod().Name);
        [HttpDelete("/DateManagement/DeleteReview")]
        public async Task<IActionResult> DeleteReview(int patientReviewId)
        => await HandleResponses.HandleResponse(() => _patientReviewBLL.DeletePatientReview(patientReviewId), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/DateManagement/GetListReview")]
        public async Task<IActionResult> GetListReview([FromQuery]PaginatorDTO paginator,byte? rating,string? cedula )
        => await HandleResponses.HandleResponse(() => _patientReviewBLL.GetListPatientReview(paginator, rating, cedula), _logService, MethodBase.GetCurrentMethod().Name);
    }
}
