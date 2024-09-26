using DateManagementMySQL.Core.Interface.Service;
using DateManagementMySQL.Infrastructure.Service;
using DateManagementMySQL.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Portafolio.Core.Interfaces.Service;
using Portafolio.Infrastructure.Services;

namespace Portafolio.Infrastructure.Service
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services) 
        {
            services.AddTransient<IExecuteStoredProcedureService, ExecuteStoredProcedureService>();
            services.AddTransient<IlogService, LogService>();
            services.AddTransient<IEmail, SendMail>();
            services.AddTransient<ISqlCommandService,SqlCommandServices>();
            services.AddTransient<IAwsService, AwsService>();
            return services;


        }
    }
}
