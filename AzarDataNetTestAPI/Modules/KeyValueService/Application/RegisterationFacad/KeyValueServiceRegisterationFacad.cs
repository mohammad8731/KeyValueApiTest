using AzarDataNetTestAPI.Modules.KeyValueService.Application.Services.Registeration;
using AzarDataNetTestAPI.Modules.KeyValueService.Infrastructure.Data.Repositories.Registeration;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Application.RegisterationFacad
{
    // add any class related to KeyValue module that supposed to be made via DI container and their lifecycle managed via DI container
    public static class KeyValueServiceRegisterationFacad
    {
        public static void AddKeyValueServiceRegisterationFacad(this IServiceCollection services)
        {
            KeyValueRepositoryRegisteration.AddKeyValueRepositoryRegisteration(services);
            KeyValueServiceRegisteration.AddKeyValueRepositoryRegisteration(services);
        }
    }
}
