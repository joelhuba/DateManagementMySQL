using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.DTOS;

namespace DateManagementMySQL.Core.Interface.BLL
{
    public interface IPatientBLL
    {
        Task<ResponseDTO> CreatePatient(PatientDTO patientDTO);
        Task<ResponseDTO> UpdatePatient(PatientDTO patientDTO);
        Task<ResponseDTO> DeletePatient(int patientId);
        Task<ResponseDTO> GetListPatients(PaginatorDTO paginatorDTO, string? cedula);
    }
}
