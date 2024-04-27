using AzarDataNetTestAPI.Modules.Common.Application.Services.KeepAlive;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Logs;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.DevelopmentStatus;
using NLog.Web;
using static AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Constants.IConstants;

namespace AzarDataNetTestAPI
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var logger = MyNLog.GetLogger(LoggerType.InfoLogger);
            try
            {
                logger.Debug("mainMethod starts");
                if (!IsDevelopment.Value)
                {
                    logger.Debug("while starts");
                    var host = CreateHostBuilder(args).Build();
                    host.Run();
                    logger.Debug("while ends");
                }
                else
                {
                    var host = CreateHostBuilder(args).Build();
                    host.Run();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "mainMethod error");
            }
            finally
            {
                logger.Debug("mainMethod ends");
                KeepAliveService.CreateAllEssentialDocs();
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                                webBuilder =>
                                {
                                    webBuilder.UseStartup<Startup>();
                                    if (!IsDevelopment.Value)
                                    {
                                        webBuilder.ConfigureKestrel(serverOptions =>
                                        {
                                            // Listen for HTTP traffic
                                            serverOptions.ListenAnyIP(5000);
                                            // Listen for HTTPS traffic
                                            serverOptions.ListenAnyIP(5001);
                                        });
                                    }
                                }
                )
                .UseNLog();  // NLog: Setup NLog for Dependency injection
    }
    public partial class Program { 

    }
}
