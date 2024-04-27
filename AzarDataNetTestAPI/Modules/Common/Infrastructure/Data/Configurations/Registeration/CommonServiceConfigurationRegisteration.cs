using AzarDataNetTestAPI.Modules.Common.Domain.Interfaces.Repositories;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Database;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.DevelopmentStatus;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.RunTime;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Urls;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.AutoMapperConfig;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.CorsConfig;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.DbContextConfig;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.DomainConfig;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.RequestLocalizationConfig;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.SwagerConfig;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.Registeration
{
    public class CommonServiceConfigurationRegisteration
    {
        public static void AddCommonServiceConfigurationRegisteration(IServiceCollection services,IConfiguration configuration,string MyAllowSpecificOrigins)
        {
            //#step1
            IsDevelopment.Value = configuration.GetValue<bool>("IsDevelopment:value");
            DatabaseConfig.DbConnection = configuration.GetConnectionString("DBConnection");
            RunTime.AppSettingsJson = File.ReadAllText(ResourceAddress.AppSettingsFile);
            //#step2
            services.AddDomainConfig(configuration);
            //#step3
            services.addCorsSingleton(configuration, MyAllowSpecificOrigins);
            services.AddDBContext(configuration);
            services.AddAutoMapper(version : 2);
            services.AddResponseCaching();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfig();
            // this service is added to di container so that we can inject httpcontext via constructor of non controller class specifically in my validation attribute subclass
            services.AddHttpContextAccessor();
            // by this config we introduce supportable cultures and pars url of request via httpContext of user request so in following services we can pass HttpContext of userRequest
            // because it has been created before ,and because of this config from now on we have correct value of culture set id property bellow :
            //httpRequest.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name
            services.ConfigRequestLocalization();
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            // excel resder
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        }
    }
}
