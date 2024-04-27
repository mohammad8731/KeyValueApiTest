using AzarDataNetTestAPI.Modules.Common.Application.Services.Registeration;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.Registeration;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories.Registeration;

namespace AzarDataNetTestAPI.Modules.Common.Application.RegisterationFacad
{
    public static class CommonServiceRegistrationFacad
    {
        // add any class related to common module that supposed to be created via DI container and their lifecycle managed via DI container
        public static void AddCommonServiceRegistrationFacad(this IServiceCollection services, IConfiguration configuration, string corsOriginName)
        {
            CommonServiceConfigurationRegisteration.AddCommonServiceConfigurationRegisteration(services,configuration,corsOriginName);
            CommonRepositoryRegisteration.AddCommonRepositoryRegisteration(services);
            CommonServiceRegisteration.AddCommonServiceRegisteration(services);
        }
    }
}
