using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portafolio.Infrastructure.BLL;
using Portafolio.Infrastructure.Repository;
using Portafolio.Infrastructure.Service;
namespace DateManagementMySQL.Infrastructure.Ioc
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDateManagementDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddRepositories(configuration);
            services.AddBussinessLogicLayer(configuration);
            services.AddService();
            return services;
        }
    }
}
