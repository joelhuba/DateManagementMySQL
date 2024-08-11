using DateManagementMySQL.Core.DTOS.Common;
using DateManagementMySQL.Core.Interface.Service;
using Microsoft.Extensions.Configuration;
using Portafolio.Core.Interfaces.Service;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Portafolio.Infrastructure.Service
{
    public  class SendMail(IConfiguration configuration, IlogService logService) : IEmail
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IlogService _logService = logService;

        public void SentEmail(SentEmailDTO sentEmailDTO)
        {

           var to = _configuration["prospects:SmtpUser"];
           var user = _configuration["prospects:SmtpUser"];
           var host = _configuration["prospects:SmtpServer"];
           var port =Convert.ToInt32( _configuration["prospects:port"]);
           var useSsl = Convert.ToBoolean( _configuration["prospects:useSsl"]);
           var password = _configuration["prospects:ApliccationPass"];

            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.Subject =sentEmailDTO.subject;
            message.Body =sentEmailDTO.body;
            message.BodyEncoding = Encoding.UTF8;
            message.Priority = MailPriority.Normal;
            message.From = new MailAddress(user, sentEmailDTO.showUser, Encoding.UTF8);
            SmtpClient smtp = new SmtpClient ();
            smtp.Host = host;
            smtp.Port = port;
            smtp.EnableSsl = useSsl;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(user, password);
            try
            {
                smtp.Send (message);
            }
            catch (Exception ex)
            {
                _logService.message($"Error al enviar el formulario : {ex.Message}");
            }

        }
    }
}
