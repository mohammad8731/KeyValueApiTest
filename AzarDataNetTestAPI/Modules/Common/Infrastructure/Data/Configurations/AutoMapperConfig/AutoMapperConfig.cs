using System.Reflection;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.AutoMapperConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapper(this IServiceCollection services, int? version)
        {
            //services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AddMaps(Assembly.GetAssembly(typeof(Startup)));
            }, typeof(Startup));
        }
    }
}
