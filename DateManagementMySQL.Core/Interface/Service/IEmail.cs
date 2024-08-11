using DateManagementMySQL.Core.DTOS.Common;

namespace Portafolio.Core.Interfaces.Service
{
    public interface IEmail
    {
        public void SentEmail(SentEmailDTO sentEmail);
    }
}
