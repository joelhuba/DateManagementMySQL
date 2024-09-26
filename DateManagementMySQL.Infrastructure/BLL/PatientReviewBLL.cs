using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using System.Reflection;

namespace DateManagementMySQL.Infrastructure.BLL
{
    public class PatientReviewBLL(IPatientReview patientReview,IlogService logService) : IPatientReviewBLL
    {
        private readonly IPatientReview _patientReview = patientReview;
        private readonly IlogService _logService = logService;
        public async Task<ResponseDTO> CreatePatientReview(PatientReviewDTO patientReviewDTO)
        {
            try
            {
                return await _patientReview.CreatePatientReview(patientReviewDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }

        }

        public async Task<ResponseDTO> DeletePatientReview(int patientReviewId)
        {
            try
            {
                return await _patientReview.DeletePatientReview(patientReviewId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListPatientReview(PaginatorDTO paginator, byte? rating, string? cedula)
        {
            try
            {
                return await _patientReview.GetListPatientReview(paginator,rating,cedula);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdatePatientReview(PatientReviewDTO patientReviewDTO)
        {
            try
            {
                return await _patientReview.UpdatePatientReview(patientReviewDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
