using DateManagementMySQL.Core.DTOS.Common;
using Org.BouncyCastle.Asn1.Ocsp;

namespace DateManagementMySQL.Core.Interface.Repository
{
    public interface IAuthUserRepository
    {
        public Task<ResponseDTO> Auth(string username);
    }
}
