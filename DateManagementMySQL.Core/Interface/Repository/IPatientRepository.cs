using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;

namespace DateManagementMySQL.Core.Interface.Respository
{ 
    public interface IPatientRepository
    {
        Task<ResponseDTO> CreatePatient(PatientDTO patientDTO);
        Task<ResponseDTO> UpdatePatient(PatientDTO patientDTO);
        Task<ResponseDTO> DeletePatient(int patientId);
        Task<ResponseDTO> GetPatients(PaginatorDTO paginatorDTO);
        Task<ResponseDTO> GetPatientByCedula(string cedula);
    }
}
