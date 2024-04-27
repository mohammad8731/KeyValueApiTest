using Microsoft.Net.Http.Headers;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.CorsConfig
{
    public static class CorsConfig
    {
        public static void addCorsSingleton(this IServiceCollection services, IConfiguration configuration, string MyAllowSpecificOrigins)
        {
            List<string> AllowedCorsOrigins = new List<string>();
            configuration.GetSection("AllowedCorsRegions").Bind(AllowedCorsOrigins);
            services.AddSingleton(AllowedCorsOrigins);
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {

                                      // Allow multiple methods  
                                      builder.WithMethods("GET", "POST", "PATCH", "DELETE", "OPTIONS")
                                        .WithHeaders(
                                          HeaderNames.Accept,
                                          HeaderNames.ContentType,
                                          HeaderNames.Authorization)
                                        .AllowCredentials()
                                        .SetIsOriginAllowed(origin =>
                                        {
                                            //AllowedCorsOrigins.ForEach(co =>origin.ToLower().StartsWith(co)==true?return true :return false );
                                            if (AllowedCorsOrigins.Any(co => origin.ToLower().StartsWith(co)))
                                            {
                                                return true;
                                            }
                                            return false;
                                            //if (string.IsNullOrWhiteSpace(origin)) return false;
                                            // Only add this to allow testing with localhost, remove this line in production!  
                                            //if (origin.ToLower().StartsWith(AllowedCorsOrigins[0])) return true;
                                            //if (origin.ToLower().StartsWith(AllowedCorsOrigins[1])) return true;
                                            //if (origin.ToLower().StartsWith(AllowedCorsOrigins[2])) return true;
                                            //if (origin.ToLower().StartsWith(AllowedCorsOrigins[3])) return true;
                                            //if (origin.ToLower().StartsWith(AllowedCorsOrigins[4])) return true;
                                            //if (origin.ToLower().StartsWith(AllowedCorsOrigins[5])) return true;
                                            //if (origin.ToLower().StartsWith(AllowedCorsOrigins[6])) return true;
                                            //if (origin.ToLower().StartsWith(AllowedCorsOrigins[7])) return true;
                                            //// Insert your production domain here.  
                                            //if (origin.ToLower().StartsWith(MainDomain.name)) return true;
                                            //return false;
                                        });
                                  });
            });
        }
    }
}
