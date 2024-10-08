﻿using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Respository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;

namespace DateManagementMySQL.Infrastructure.Repository
{
    public class PatientRepository(IExecuteStoredProcedureService executeStoredProcedure) : IPatientRepository
    {
        IExecuteStoredProcedureService _executeStoredProcedure = executeStoredProcedure;

        public async Task<ResponseDTO> CreatePatient(PatientDTO patientDTO)
        {
            object obj = new
            {
                patientDTO.Name,
                patientDTO.LastName,
                patientDTO.Cedula,
                patientDTO.IdEps,
                patientDTO.PhoneNumber,
                patientDTO.EpsCode,
                patientDTO.UseWhatsApp
            };
            return await _executeStoredProcedure.ExecuteStoredProcedure("CreatePatient", obj);
        }

        public async Task<ResponseDTO> DeletePatient(int patientId)
        {
            object obj = new
            {
                PatientId = patientId
            };
            return await _executeStoredProcedure.ExecuteStoredProcedure("DeletePatient", obj);
        }

     
        public async Task<ResponseDTO> GetListPatients(PaginatorDTO paginatorDTO, string? cedula)
        {
            object obj = new
            {
                paginatorDTO.PageSize,
                paginatorDTO.PageIndex,
                Cedula = cedula
            }; 
            return await _executeStoredProcedure.ExecuteTableStoredProcedure("GetListPatients", obj, MapToListHelper.MapToList<PatientDTO>);
        }

        public async Task<ResponseDTO> UpdatePatient(PatientDTO patientDTO)
        {
            object obj = new
            {
                patientDTO.PatientId,
                patientDTO.Name,
                patientDTO.LastName,
                patientDTO.IdEps,
                patientDTO.PhoneNumber,
                patientDTO.EpsCode,
                patientDTO.UseWhatsApp
            };
            return await _executeStoredProcedure.ExecuteStoredProcedure("UpdatePatient", obj);
        }
    }
}
