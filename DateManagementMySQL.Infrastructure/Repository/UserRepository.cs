using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Respository;
using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Extensions;

namespace DateManagementMySQL.Infrastructure.Repository
{
    public class UserRepository(IExecuteStoredProcedureService executeStoredProcedure) : IUserRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedure; 
        public async Task<ResponseDTO> DelUser(int idUser)
        {
            object obj = new
            {
                IdUser = idUser
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("DelUser", obj);
        }

        public async Task<ResponseDTO> CreateUser(UserDTO userDTO)
        {
            object obj = new
            {
                userDTO.Name,
                userDTO.LastName,
                userDTO.UserName,
                userDTO.PassWord,
                userDTO.PassWordSalt,
                userDTO.Email,
                userDTO.IdRol
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("CreateUser",obj);
        }

        public async Task<ResponseDTO> UpdateUser(UserDTO userDTO)
        {
            object obj = new
            {
                userDTO.IdUser,
                userDTO.Name,
                userDTO.LastName,
                userDTO.UserName,
                userDTO.Email,
                userDTO.IdRol
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdateUser", obj);
        }

        public async Task<ResponseDTO> GetListUsers(PaginatorDTO paginator, int? idUser)
        {
            object obj = new
            {
                paginator.PageIndex,
                paginator.PageSize,
                IdUser = idUser,
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure<UserDTO>("GetListUsers", obj, MapToListHelper.MapToList<UserDTO>);
        }
    }
}
