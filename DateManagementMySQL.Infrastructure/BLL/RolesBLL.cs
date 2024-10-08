﻿using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Respository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Core.Interfaces.BLL;
using DateManagementMySQL.Infrastructure.Extensions;
using System.Reflection;

namespace DateManagementMySQL.Infrastructure.BLL
{
    public class RolesBLL(IRolesRepository roles, IlogService logService) : IRolesBLL
    {
        private readonly IRolesRepository _rolesRepository = roles ;
        private readonly IlogService _logService = logService;
        public async Task<ResponseDTO> CreateRol(RolesDTO roles)
        {

            try
            {
             return await _rolesRepository.CreateRol(roles);   
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> DeleteRol(int Idrol)
        {
            try
            {
                return await _rolesRepository.DeleteRol(Idrol);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListRoles(PaginatorDTO paginator, string? description)
        {
            try
            {
                return await _rolesRepository.GetListRoles(paginator, description);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }


        public async Task<ResponseDTO> UpdateRol(RolesDTO roles)
        {
            try
            {
                return await _rolesRepository.UpdateRol(roles);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
