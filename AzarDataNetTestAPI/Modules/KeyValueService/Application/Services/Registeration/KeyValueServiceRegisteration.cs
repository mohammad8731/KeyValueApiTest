using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Interfaces.Services;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Application.Services.Registeration
{
    public class KeyValueServiceRegisteration
    {
        public static void AddKeyValueRepositoryRegisteration(IServiceCollection services)
        {
            services.AddScoped<IKeyValueService,KeyValueService>();
        }
    }
}
