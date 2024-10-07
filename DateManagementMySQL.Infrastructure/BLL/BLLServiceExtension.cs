using DateManagementMySQL.Core.Interface.BLL;
using DateManagementMySQL.Core.Interfaces.BLL;
using DateManagementMySQL.Infrastructure.BLL;
using DateManagementMySQL.Infrastructure.BLL.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Portafolio.Infrastructure.BLL
{
    public static class BLLServiceExtension
    {
        public static IServiceCollection AddBussinessLogicLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddTransient<IUserBLL,UserBLL>();
            services.AddTransient<IRolesBLL,RolesBLL>();
            services.AddTransient<IEpsBLL,EpsBLL>();
            services.AddTransient<IPatientBLL,PatientBLL>();
            services.AddTransient<IAuthBLL,AuthBLL>();
            services.AddTransient<IPatientReviewBLL,PatientReviewBLL>();
            services.AddTransient<IAwsServiceBLL,AwsServiceBLL>();
            services.AddTransient<IAwsImageBLL, ImageAwsBLL>();
            services.AddTransient<ISectionBLL, SectionBLL>();
            return services;
        }
    }
}
