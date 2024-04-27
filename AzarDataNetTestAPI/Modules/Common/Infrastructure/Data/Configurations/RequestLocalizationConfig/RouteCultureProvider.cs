using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.RequestLocalizationConfig
{
    public class RouteCultureProvider : IRequestCultureProvider
    {
        private CultureInfo defaultCulture;
        private CultureInfo defaultUICulture;
        private List<CultureInfo> _supportedCulture;

        public RouteCultureProvider(RequestCulture requestCulture, List<CultureInfo> supportedCulture)
        {
            defaultCulture = requestCulture.Culture;
            defaultUICulture = requestCulture.UICulture;
            _supportedCulture = supportedCulture;


        }

        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            //Parsing language from url path, which looks like "/en/home/index"
            PathString url = httpContext.Request.Path;

            // Test any culture in route
            if (url.ToString().Length <= 1)
            {
                CultureInfo.CurrentCulture = new CultureInfo(defaultCulture.TwoLetterISOLanguageName);
                // Set default Culture and default UICulture
                return Task.FromResult(new ProviderCultureResult(defaultCulture.TwoLetterISOLanguageName, defaultUICulture.TwoLetterISOLanguageName));
            }

            var parts = httpContext.Request.Path.Value.Split('/');
            var culture = parts[1];

            // Test if the culture is properly formatted
            //if (!Regex.IsMatch(culture, @"^[a-z]{2}(-[A-Z]{2})*$"))
            //{
            //    // Set default Culture and default UICulture
            //    return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(this.defaultCulture.TwoLetterISOLanguageName, this.defaultUICulture.TwoLetterISOLanguageName));
            //}
            foreach (var c in _supportedCulture)
            {
                if (culture == c.Name)
                {
                    CultureInfo.CurrentCulture = new CultureInfo(culture);
                    //Set Culture and UICulture from route culture parameter
                    return Task.FromResult(new ProviderCultureResult(culture, culture));

                }

            }

            CultureInfo.CurrentCulture = new CultureInfo(defaultCulture.TwoLetterISOLanguageName);
            // Set default Culture and default UICulture
            return Task.FromResult(new ProviderCultureResult(defaultCulture.TwoLetterISOLanguageName, defaultUICulture.TwoLetterISOLanguageName));

            // Set Culture and UICulture from route culture parameter
            //return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(culture, culture));
        }
    }
}
