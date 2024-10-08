﻿using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DateManagementMySQL.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IPatientBLL patientBLL,IlogService IlogService) : ControllerBase
    {
        IPatientBLL _patientBLL = patientBLL;
        IlogService _IlogService = IlogService;
        
        [HttpPost("/DateManagement/CreatePatient")]
        public async Task<IActionResult> CreatePatient(PatientDTO patientDTO)
        => await HandleResponses.HandleResponse(()=>_patientBLL.CreatePatient(patientDTO),_IlogService,MethodBase.GetCurrentMethod().Name);

        [HttpPut("/DateManagement/UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(PatientDTO patientDTO)
        => await HandleResponses.HandleResponse(() => _patientBLL.UpdatePatient(patientDTO), _IlogService, MethodBase.GetCurrentMethod().Name);


        [HttpDelete("/DateManagement/DeletePatient")]
        public async Task<IActionResult> DeletePatient(int patientId)
        => await HandleResponses.HandleResponse(() => _patientBLL.DeletePatient(patientId), _IlogService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/DateManagement/GetListPatients")]
        public async Task<IActionResult> GetListPatients([FromQuery]PaginatorDTO paginatorDTO, string? cedula)
        => await HandleResponses.HandleResponse(() => _patientBLL.GetListPatients(paginatorDTO, cedula), _IlogService, MethodBase.GetCurrentMethod().Name);

    }
}
