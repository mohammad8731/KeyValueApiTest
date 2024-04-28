using NLog.Web;
using static AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Constants.IConstants;
using ILogger = NLog.ILogger;

namespace AzarDataNetTestAPI.Modules.Common.Application.Services.Logs
{
    public class MyNLog
    {
        private static ILogger DatabaseExpLogger;
        private static ILogger FileIOExpLogger;
        private static ILogger InfoLogger;
        private static ILogger OtherExpLogger;
        private static ILogger UserLogger;
        private static ILogger MemoryLogger;
        private static ILogger SendingMessageLogger;
        private static ILogger CompanyBalanceLogger;
        private static ILogger PaymentLoggerStp1;
        private static ILogger PaymentLoggerStp2;
        private static ILogger PaymentLoggerStp3;
        private static ILogger PaymentLoggerStp4;
        private static ILogger BasketThirdPartyConnectionLogger;
        private static ILogger BasketDBOperationFailedLogger;
        private static ILogger BasketBaseExceptionLogger;
        private static ILogger BasketOtherExceptionLogger;
        private static ILogger WalletBaseExceptionLogger;
        private static ILogger WalletDBOperationFailedLogger;
        private static ILogger WalletOtherExceptionLogger;
        private static ILogger WalletThirdPartyConnectionLogger;
        private static ILogger FinancialExpLogger;
        private MyNLog()
        {

        }
        private static ILogger GetLoggerInstance(LoggerType loggerType)
        {
            return NLogBuilder.ConfigureNLog("nlog.config").GetLogger(loggerType.ToString());
            //return NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetLogger(loggerType);
        }

        public static ILogger GetLogger(System.Exception exToBeLogged, string CallerMethodName)
        {
            var callerClassName = GetCallerClassName(exToBeLogged);
            return GetLogger(LoggerType.OtherExpLogger);
        }

        private static string GetCallerClassName(System.Exception exToBeLogged)
        {
            var startIndex = exToBeLogged.StackTrace.IndexOf(" in ");
            var endtIndex = exToBeLogged.StackTrace.IndexOf(" at ", startIndex);
            if (endtIndex == -1)
            {
                endtIndex = (exToBeLogged.StackTrace.Length - 1);
            }
            var traceSubString = exToBeLogged.StackTrace.Substring(startIndex, endtIndex - startIndex);
            int lastSlash = traceSubString.LastIndexOf(@"\");
            int firstDotAdfterSlash = traceSubString.IndexOf(".");
            return traceSubString.Substring(lastSlash + 1, firstDotAdfterSlash - 2 - lastSlash + 1);
        }

        public static ILogger GetLogger(LoggerType loggerType)
        {
            if (loggerType == LoggerType.DatabaseExpLogger)
            {
                if (DatabaseExpLogger == null)
                {
                    return DatabaseExpLogger = GetLoggerInstance(LoggerType.DatabaseExpLogger);
                }
                else
                {
                    return DatabaseExpLogger;
                }
            }
            else if (loggerType == LoggerType.FileIOExpLogger)
            {
                if (FileIOExpLogger == null)
                {
                    return FileIOExpLogger = GetLoggerInstance(LoggerType.FileIOExpLogger);
                }
                else
                {
                    return FileIOExpLogger;
                }
            }
            else if (loggerType == LoggerType.OtherExpLogger)
            {
                if (OtherExpLogger == null)
                {
                    return OtherExpLogger = GetLoggerInstance(LoggerType.OtherExpLogger);
                }
                else
                {
                    return OtherExpLogger;
                }
            }
            else if (loggerType == LoggerType.InfoLogger)
            {
                if (InfoLogger == null)
                {
                    return InfoLogger = GetLoggerInstance(LoggerType.InfoLogger);
                }
                else
                {
                    return InfoLogger;
                }
            }
            else if (loggerType == LoggerType.UserLogger)
            {
                if (UserLogger == null)
                {
                    return UserLogger = GetLoggerInstance(LoggerType.UserLogger);
                }
                else
                {
                    return UserLogger;
                }
            }
            else if (loggerType == LoggerType.MemoryLogger)
            {
                if (MemoryLogger == null)
                {
                    return MemoryLogger = GetLoggerInstance(LoggerType.MemoryLogger);
                }
                else
                {
                    return MemoryLogger;
                }
            }
            else if (loggerType == LoggerType.SendingMessageLogger)
            {
                if (SendingMessageLogger == null)
                {
                    return SendingMessageLogger = GetLoggerInstance(LoggerType.SendingMessageLogger);
                }
                else
                {
                    return SendingMessageLogger;
                }
            }
            else if (loggerType == LoggerType.CompanyBalanceLogger)
            {
                if (CompanyBalanceLogger == null)
                {
                    return CompanyBalanceLogger = GetLoggerInstance(LoggerType.CompanyBalanceLogger);
                }
                else
                {
                    return CompanyBalanceLogger;
                }
            }
            else if (loggerType == LoggerType.PaymentLoggerStp1)
            {
                if (PaymentLoggerStp1 == null)
                {
                    return PaymentLoggerStp1 = GetLoggerInstance(LoggerType.PaymentLoggerStp1);
                }
                else
                {
                    return PaymentLoggerStp1;
                }
            }
            else if (loggerType == LoggerType.PaymentLoggerStp2)
            {
                if (PaymentLoggerStp2 == null)
                {
                    return PaymentLoggerStp2 = GetLoggerInstance(LoggerType.PaymentLoggerStp2);
                }
                else
                {
                    return PaymentLoggerStp2;
                }
            }
            else if (loggerType == LoggerType.PaymentLoggerStp3)
            {
                if (PaymentLoggerStp3 == null)
                {
                    return PaymentLoggerStp3 = GetLoggerInstance(LoggerType.PaymentLoggerStp3);
                }
                else
                {
                    return PaymentLoggerStp3;
                }
            }
            else if (loggerType == LoggerType.PaymentLoggerStp4)
            {
                if (PaymentLoggerStp4 == null)
                {
                    return PaymentLoggerStp4 = GetLoggerInstance(LoggerType.PaymentLoggerStp4);
                }
                else
                {
                    return PaymentLoggerStp4;
                }
            }
            else if (loggerType == LoggerType.BasketThirdPartyConnectionLogger)
            {
                if (BasketThirdPartyConnectionLogger == null)
                {
                    return BasketThirdPartyConnectionLogger = GetLoggerInstance(LoggerType.BasketThirdPartyConnectionLogger);
                }
                else
                {
                    return BasketThirdPartyConnectionLogger;
                }
            }
            else if (loggerType == LoggerType.BasketDBOperationFailedLogger)
            {
                if (BasketDBOperationFailedLogger == null)
                {
                    return BasketDBOperationFailedLogger = GetLoggerInstance(LoggerType.BasketDBOperationFailedLogger);
                }
                else
                {
                    return BasketDBOperationFailedLogger;
                }
            }
            else if (loggerType == LoggerType.BasketBaseExceptionLogger)
            {
                if (BasketBaseExceptionLogger == null)
                {
                    return BasketBaseExceptionLogger = GetLoggerInstance(LoggerType.BasketBaseExceptionLogger);
                }
                else
                {
                    return BasketBaseExceptionLogger;
                }
            }
            else if (loggerType == LoggerType.BasketOtherExceptionLogger)
            {
                if (BasketOtherExceptionLogger == null)
                {
                    return BasketOtherExceptionLogger = GetLoggerInstance(LoggerType.BasketOtherExceptionLogger);
                }
                else
                {
                    return BasketOtherExceptionLogger;
                }
            }
            else if (loggerType == LoggerType.WalletBaseExceptionLogger)
            {
                if (WalletBaseExceptionLogger == null)
                {
                    return WalletBaseExceptionLogger = GetLoggerInstance(LoggerType.WalletBaseExceptionLogger);
                }
                else
                {
                    return WalletBaseExceptionLogger;
                }
            }
            else if (loggerType == LoggerType.WalletDBOperationFailedLogger)
            {
                if (WalletDBOperationFailedLogger == null)
                {
                    return WalletDBOperationFailedLogger = GetLoggerInstance(LoggerType.WalletDBOperationFailedLogger);
                }
                else
                {
                    return WalletDBOperationFailedLogger;
                }
            }
            else if (loggerType == LoggerType.WalletOtherExceptionLogger)
            {
                if (WalletOtherExceptionLogger == null)
                {
                    return WalletOtherExceptionLogger = GetLoggerInstance(LoggerType.WalletOtherExceptionLogger);
                }
                else
                {
                    return WalletOtherExceptionLogger;
                }
            }
            else if (loggerType == LoggerType.WalletThirdPartyConnectionLogger)
            {
                if (WalletThirdPartyConnectionLogger == null)
                {
                    return WalletThirdPartyConnectionLogger = GetLoggerInstance(LoggerType.WalletThirdPartyConnectionLogger);
                }
                else
                {
                    return WalletThirdPartyConnectionLogger;
                }
            }
            else if (loggerType == LoggerType.FinancialExpLogger)
            {
                if (FinancialExpLogger == null)
                {
                    return FinancialExpLogger = GetLoggerInstance(LoggerType.FinancialExpLogger);
                }
                else
                {
                    return FinancialExpLogger;
                }
            }
            else return null;
        }
    }
}
