using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateManagementMySQL.Core.Interface.BLL
{
    public interface IPatientReviewBLL
    {
        Task<ResponseDTO> CreatePatientReview(PatientReviewDTO patientReviewDTO);
        Task<ResponseDTO> UpdatePatientReview(PatientReviewDTO patientReviewDTO);
        Task<ResponseDTO> DeletePatientReview(int patientReviewId);
        Task<ResponseDTO> GetListPatientReview(PaginatorDTO paginator, byte? rating, string? cedula);
    }
}
