using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Interfaces.Repositories;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Infrastructure.Data.Repositories.Registeration
{
    public class KeyValueRepositoryRegisteration
    {
        public static void AddKeyValueRepositoryRegisteration(IServiceCollection services)
        {
            services.AddScoped<IKeyValueRepository,KeyValueRepository>();
        }
    }
}
