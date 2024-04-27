using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.DevelopmentStatus;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Urls;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.DomainConfig
{
    public static class DomainConfig
    {
        public static void AddDomainConfig(this IServiceCollection services, IConfiguration _conFiguration)
        {
            if (IsDevelopment.Value)
            {
                MainDomain.name = _conFiguration.GetValue<string>("Domain:local");
            }
            else
            {
                MainDomain.name = _conFiguration.GetValue<string>("Domain:server");
            }
        }
    }
}
