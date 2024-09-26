using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;

namespace DateManagementMySQL.Core.Interface.Respository
{ 
    public interface IPatientRepository
    {
        Task<ResponseDTO> CreatePatient(PatientDTO patientDTO);
        Task<ResponseDTO> UpdatePatient(PatientDTO patientDTO);
        Task<ResponseDTO> DeletePatient(int patientId);
        Task<ResponseDTO> GetListPatients(PaginatorDTO paginatorDTO, string? cedula);
    }
}
