using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Respository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using System.Reflection;

namespace DateManagementMySQL.Infrastructure.BLL
{
    public class PatientBLL(IPatientRepository patientRepository,IlogService logService) : IPatientBLL
    {
        IPatientRepository _patient = patientRepository;
        IlogService _logService = logService;

        public async Task<ResponseDTO> CreatePatient(PatientDTO patientDTO)
        {
            try
            {
                return await _patient.CreatePatient(patientDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService,MethodBase.GetCurrentMethod().Name , ex);
            }
        }

        public async Task<ResponseDTO> DeletePatient(int patientId)
        {
            try
            {
                return await _patient.DeletePatient(patientId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

      

        public async Task<ResponseDTO> GetListPatients(PaginatorDTO paginatorDTO, string? cedula)
        {
            try
            {
                return await _patient.GetListPatients(paginatorDTO, cedula);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdatePatient(PatientDTO patientDTO)
        {
            try
            {
                return await _patient.UpdatePatient(patientDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
