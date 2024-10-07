using DateManagementMySQL.Core.Interface.DataContext;
using DateManagementMySQL.Core.Interface.Repository;
using DateManagementMySQL.Core.Interface.Respository;
using DateManagementMySQL.Infrastructure.DataContext;
using DateManagementMySQL.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Portafolio.Infrastructure.Repository
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton(configuration);
            services.AddTransient<IDataContext,DataContext>();
            services.AddTransient<IepsRepository,EpsRepository>();
            services.AddTransient<IRolesRepository,RolesRepository>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IPatientRepository,PatientRepository>();
            services.AddTransient<IAuthUserRepository, AuthRepository>();
            services.AddTransient<IPatientReview,PatientReviewRepository>();
            services.AddTransient<IAwsImagesRepository, AwsImagesRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            return services;
        }
    }
}
