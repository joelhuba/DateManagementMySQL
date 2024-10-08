﻿using DateManagementMySQL.Core.DTOS;
using DateManagementMySQL.Core.DTOS.Common;

namespace DateManagementMySQL.Core.Interface.Respository
{ 
    public interface IUserRepository
    {
        public Task<ResponseDTO> CreateUser(UserDTO userDTO);
        public Task<ResponseDTO> UpdateUser(UserDTO userDTO);
        public Task<ResponseDTO> GetListUsers(PaginatorDTO paginator,int? idUser);
        public Task<ResponseDTO> DelUser(int idUser);
    }
}
