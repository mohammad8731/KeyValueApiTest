using Asp.Versioning;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.ApiVersioning
{
    public static class APiVersioningConfig
    {
        public static void AddApiVersioningConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                // api version added to request header by bellow bool
                config.ReportApiVersions = true;
            });
        }

    }
}
