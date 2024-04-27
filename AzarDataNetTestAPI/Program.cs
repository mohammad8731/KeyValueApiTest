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
                    //while (RunTime.ContinuesRun)
                    //{
                    //    logger.Debug("while starts");
                    //    var host = CreateHostBuilder(args).Build();
                    //    host.Run();
                    //    //Console.WriteLine( KeepAliveService.thread.ThreadState);
                    //    // if server : ContinuesRun is true if me ContinuesRun gets false
                    //    if (RunTime.ContinuesRun && !IsDevelopment.Value)
                    //    {
                    //        FileManager.WriteNewFile(ResourceAddress.AppSettingsFile, RunTime.AppSettingsJson);
                    //    }
                    //    logger.Debug("while ends");
                    //}

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
                //sendsms();
                logger.Debug("mainMethod ends");
                KeepAliveService.CreateAllEssentialDocs();
                NLog.LogManager.Shutdown();
            }
        }

        //public static void sendsms()
        //{
        //    var smsService = TabanSendSMSService.SendSmsMessageWithPostMethodStatic(
        //        new SendSmsDto { PatternType = PatternType.ResetPass.ToString(), SenderPhoneNumberType = SenderPhoneNumberType.BlackList5000.ToString(), PhoneOrUserName = "9175027109", code = "20" });
        //}
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
