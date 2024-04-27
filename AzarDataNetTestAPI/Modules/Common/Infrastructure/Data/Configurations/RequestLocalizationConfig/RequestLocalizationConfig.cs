using System.Globalization;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Languages;
using Microsoft.AspNetCore.Localization;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.RequestLocalizationConfig
{
    public static class RequestLocalizationConfig
    {
        public static void ConfigRequestLocalization(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo(Language.en_US),
                    new CultureInfo(Language.fa_IR),
                    //new CultureInfo("fr-FR"),
                };
                //opt.DefaultRequestCulture = new RequestCulture(culture: "fa-IR", uiCulture: "fa-IR");
                opt.DefaultRequestCulture = new RequestCulture(Language.fa_IR);
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;
                opt.RequestCultureProviders = new[] { new RouteCultureProvider(opt.DefaultRequestCulture, supportedCultures) };
            });
        }
    }
}
