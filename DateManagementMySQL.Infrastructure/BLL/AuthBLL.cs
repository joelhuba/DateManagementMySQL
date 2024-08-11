using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;
using DateManagementMySQL.Infrastructure.Repository;
using DateManagementMySQL.Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using transversal_layer_back.Infrastructure.Helpers;

namespace DateManagementMySQL.Infrastructure.BLL
{
    public class AuthBLL(IAuthUserRepository authUserRepository,IlogService logService,IConfiguration configuration) : IAuthBLL
    {
        private readonly IAuthUserRepository _authUserRepository = authUserRepository;
        private readonly IlogService _logService = logService;
        private readonly IConfiguration _configuration = configuration;
        public async Task<ResponseDTO> Auth(string username, string password)
        {
            ResponseDTO response = new ResponseDTO { IsSuccess = false };
            try
            {
                response = await _authUserRepository.Auth(username);
                AuthUserDTO user = (AuthUserDTO)response.Data;
                byte[] saltPass = Convert.FromBase64String(user.PassWordSalt);
                if (PasswordHashHelper.VerifyPassword(password, user.PassWord, saltPass))
                {
                    response.IsSuccess = true;
                    response.Message = "Usuario autenticado con éxito";
                    response.Data = await GenerateTokenHelper.GenerateTokenAsync(user, _configuration["TokenSettings:SecretToken"], Convert.ToInt32(_configuration["TokenSettings:TokenExpirationHours"]), _logService);
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Credenciales inválidas";
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            return response;
        }
    }
}
