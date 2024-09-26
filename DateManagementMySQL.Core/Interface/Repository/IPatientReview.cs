using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateManagementMySQL.Core.Interface.Repository
{
    public interface IPatientReview
    {
        Task<ResponseDTO> CreatePatientReview(PatientReviewDTO patientReviewDTO);
        Task<ResponseDTO> UpdatePatientReview(PatientReviewDTO patientReviewDTO);
        Task<ResponseDTO> DeletePatientReview(int patientReviewId);
        Task<ResponseDTO> GetListPatientReview(PaginatorDTO paginator, byte? rating, string? cedula);
    }
}
