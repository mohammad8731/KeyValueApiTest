using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.ServiceResult.Response;
using AzarDataNetTestAPI.Modules.Common.Application.Middleware;
using AzarDataNetTestAPI.Modules.Common.Application.RegisterationFacad;
using AzarDataNetTestAPI.Modules.Common.Application.Services.KeepAlive;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.SwagerConfig;
using AzarDataNetTestAPI.Modules.KeyValueService.Application.RegisterationFacad;

namespace AzarDataNetTestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //ScheduleService.StartReadyDatabaseRamAsync().GetAwaiter().GetResult();
            _Configuration = configuration;
        }

        public IConfiguration _Configuration { get; }
        public string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add any class related to common module that supposed to be made via DI container and their lifecycle managed via DI container
            services.AddCommonServiceRegistrationFacad(_Configuration,MyAllowSpecificOrigins);
            services.AddKeyValueServiceRegisterationFacad();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSwaggerConfig();

            app.UseApiExceptionHandling();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseResponseCaching();

            // 403 custom forbidden error
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    context.Response.ContentType = "application/json";
                    ResultDto resultDto = new ResultDto { IsSuccess = false, Message = "دسترسی شما به این بخش ممنوع است" };
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(resultDto));
                }
            });

            var localizeOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizeOption.Value);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


            //keep alive
            //IHostApplicationLifetime
            var hostLifetime = (IHostApplicationLifetime)app.ApplicationServices.GetRequiredService(typeof(IHostApplicationLifetime));
            KeepAliveService.start(hostLifetime.ApplicationStopping);

        }
    }
}