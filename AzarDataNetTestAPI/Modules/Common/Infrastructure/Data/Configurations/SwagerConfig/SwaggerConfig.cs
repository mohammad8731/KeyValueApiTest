using System.Reflection;
using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.SwagerConfig
{
    public static class SwaggerConfig
    {
        private readonly static string swaggerBasePath = "dsdkhkhdihwfi";
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
                // Add the custom operation filter
                //options.OperationFilter<ApplyFromBodyToAllComplexTypeParameters>();

                //options.DocInclusionPredicate((version, desc) =>
                //{
                //    if (!desc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                //    var versions = methodInfo.DeclaringType.GetCustomAttributes(true).OfType<ApiVersionAttribute>().SelectMany(attr => attr.Versions);
                //    //var maps = methodInfo.GetCustomAttributes(true).OfType<MapToApiVersionAttribute>().SelectMany(attr => attr.Versions).ToArray();
                //    version = version.Replace("v", "");
                //    return versions.Any(v => v.ToString() == version
                //    //&& maps.Any(v => v.ToString() == version)
                //    );
                //});
                options.DocInclusionPredicate((version, desc) =>
                {
                    if (!desc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;
                    var versions = methodInfo.DeclaringType
                                    .GetCustomAttributes(true)
                                    .OfType<ApiVersionAttribute>()
                                    .SelectMany(attr => attr.Versions);
                    //var maps = methodInfo.GetCustomAttributes(true).OfType<MapToApiVersionAttribute>().SelectMany(attr => attr.Versions).ToArray();
                    version = version.Replace("v", "");
                    return versions.Any(v => v.ToString() == version
                    //&& maps.Any(v => v.ToString() == version)
                    );
                });

                // remove version parameter from all paths of swager ui
                options.OperationFilter<RemoveVersionParameter>();
                // set version value of all paths based on swager version
                options.DocumentFilter<SetVersionInPaths>();

                // enable multiple example for requests
                options.ExampleFilters();

                // enable xml comment
                //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlFilename = $"{Assembly.GetAssembly(typeof(Startup)).GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            });
            // to automatically search all the example from assembly.
            //services.AddSwaggerExamplesFromAssemblyOf<Startup>();
            // to search out of webapp project , its enough to pass one of application classs type to search all example from there
            services.AddSwaggerExamplesFromAssemblyOf<Program>();
            services.AddApiVersioning();
        }

        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = swaggerBasePath + "/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{swaggerBasePath}/swagger/v1/swagger.json", "Karyabi v1");
                c.SwaggerEndpoint($"/{swaggerBasePath}/swagger/v2/swagger.json", "Karyabi v2");
                c.RoutePrefix = $"{swaggerBasePath}/swagger";
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
            }
            );
            //app.UseSwagger(c =>
            //{
            //    c.RouteTemplate = "mycoolapi/swagger/{documentname}/swagger.json";
            //});


            //app.UseSwaggerUI(c =>
            //{
            //    //c.DocumentTitle = "Test Title";
            //    c.SwaggerEndpoint("/mycoolapi/swagger/v1/swagger.json", "My Cool API V1");
            //    c.SwaggerEndpoint("/mycoolapi/swagger/v2/swagger.json", "My Cool API V2");
            //    c.RoutePrefix = "mycoolapi/swagger";
            //});
        }

    }
}
