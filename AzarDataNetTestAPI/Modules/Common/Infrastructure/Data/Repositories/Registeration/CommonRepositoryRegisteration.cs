using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories.Common;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories.Registeration
{
    public class CommonRepositoryRegisteration
    {
        public static void AddCommonRepositoryRegisteration(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
