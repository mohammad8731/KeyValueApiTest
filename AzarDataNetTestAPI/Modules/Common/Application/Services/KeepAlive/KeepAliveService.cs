using System.Diagnostics;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Logs;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Urls;
using RestSharp;
using static AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Constants.IConstants;

namespace AzarDataNetTestAPI.Modules.Common.Application.Services.KeepAlive
{
    public class KeepAliveService
    {
        public static Thread thread { set; get; }
        public static CancellationToken _CancellationToken { get; set; }
        public static void start(CancellationToken cancellationToken)
        {
            WipeAllEssentialDocs();
            _CancellationToken = cancellationToken;
            ThreadStart childref = new ThreadStart(m);
            thread = new Thread(childref);
            thread.Start();
        }
        private async static void m()
        {
            var client = new RestClient(MainDomain.name + "fa/v1/google/temp");
            var request = new RestRequest();
            request.Method = Method.Get;
            Process proc = Process.GetCurrentProcess();
            var logger = MyNLog.GetLogger(LoggerType.MemoryLogger);
            while (true)
            {
                //await client.ExecuteAsync(request, _CancellationToken);
                Console.Write("m");
                proc.Refresh();
                var gcTotoalMem = GC.GetTotalMemory(true);
                logger.Info("Gc:" + gcTotoalMem / (1024 * 1024) + " ws64:" + proc.WorkingSet64 / (1024 * 1024) + " pm64:" + proc.PrivateMemorySize64 / (1024 * 1024) + " virtualmSize:" + proc.VirtualMemorySize64 / (1024 * 1024));
                Thread.Sleep(180000);
            }
        }
        private static void WipeAllEssentialDocs()
        {
            //if (!IsDevelopment.Value)
            //{
            //    FileManager.WipeFile(ResourceAddress.AppSettingsFile, 2);
            //    FileManager.WipeFile(ResourceAddress.AppSettingsDevelopmentFile, 2);
            //    FileManager.WipeFile(ResourceAddress.AppSettingsProductionFile, 2);
            //}
        }
        public static void CreateAllEssentialDocs()
        {
            //if (!IsDevelopment.Value && RunTime.ContinuesRun)
            //{
            //    FileManager.WriteNewFile(ResourceAddress.AppSettingsFile, RunTime.AppSettingsJson);
            //}
        }
    }
}
