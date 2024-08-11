using DateManagementMySQL.Core.Interface.Service;
using Microsoft.Extensions.Configuration;

namespace DateManagementMySQL.Infrastructure.Service
{
    public class LogService : IlogService
    {
        private readonly IConfiguration _configuration;
        public LogService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void message(string message)
        {
            var route = _configuration["logRoute"];
            var directoryRoute = Path.GetDirectoryName(route);
            var fileName = Path.GetFileName(route);
            var combinepath = Path.Combine(directoryRoute, fileName);
            if (!Directory.Exists(combinepath))
            { 
             Directory.CreateDirectory(directoryRoute);
            }
            using (StreamWriter writer = new StreamWriter(combinepath,true))
            {
                writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss")}] : {message}");
            }
        }
    }
}
