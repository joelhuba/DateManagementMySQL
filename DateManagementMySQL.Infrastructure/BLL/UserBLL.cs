using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Respository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Core.Interfaces.BLL;
using DateManagementMySQL.Infrastructure.Extensions;
using System.Reflection;
using transversal_layer_back.Infrastructure.Helpers;

namespace Portafolio.Infrastructure.BLL
{
    public class UserBLL(IUserRepository user,IlogService logService) : IUserBLL
    {
        private IUserRepository _userRepository = user;
        private IlogService _logService = logService;

        public async Task<ResponseDTO> CreateUser(UserDTO userDTO)
        {
           
            try
            {
                var (passwordHased, salt) = PasswordHashHelper.HashPassword(userDTO.PassWord);
                userDTO.PassWord = passwordHased;
                userDTO.PassWordSalt = salt;
                return await _userRepository.CreateUser(userDTO);
            }
            catch(Exception ex) 
            { 
                return ExceptionHelper.HandleException(_logService,MethodBase.GetCurrentMethod().Name,ex);
            }
        }

        public async Task<ResponseDTO> DelUser(int idUser)
        {
            try
            {
              return await  _userRepository.DelUser(idUser);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListUsers(PaginatorDTO paginator, int? idUser)
        {
            try
            {
                return await _userRepository.GetListUsers(paginator, idUser);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }


        public async Task<ResponseDTO> UpdateUser(UserDTO userDTO)
        {
            try
            {
                return await _userRepository.UpdateUser(userDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
