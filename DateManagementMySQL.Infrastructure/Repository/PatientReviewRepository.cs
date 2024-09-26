using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.DTOS.resposne;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateManagementMySQL.Infrastructure.Repository
{
    public class PatientReviewRepository(IExecuteStoredProcedureService executeStoredProcedureService) : IPatientReview     
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedureService;
        public async Task<ResponseDTO> CreatePatientReview(PatientReviewDTO patientReviewDTO)
        {
            object obj = new
            {
                patientReviewDTO.PatientId,
                patientReviewDTO.Rating,
                patientReviewDTO.ReviewText
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("CreatePatientReview", obj);
        }

        public async Task<ResponseDTO> DeletePatientReview(int patientReviewId)
        {
            object obj = new
            {
                PatientReviewId = patientReviewId
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("DeletePatientReview", obj);
        }

        public async Task<ResponseDTO> GetListPatientReview(PaginatorDTO paginator, byte? rating, string? cedula)
        {
            object obj = new
            {
                paginator.PageIndex,
                paginator.PageSize,
                Rating = rating,
                Cedula = cedula
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure("GetListReviews", obj,MapToListHelper.MapToList<PatientReviewResponseDTO>);
        }

        public async Task<ResponseDTO> UpdatePatientReview(PatientReviewDTO patientReviewDTO)
        {
            object obj = new
            {
                patientReviewDTO.IdReview,
                patientReviewDTO.Rating,
                patientReviewDTO.ReviewText
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdatePatientReview", obj);
        }
    }
}
