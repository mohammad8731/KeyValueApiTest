using System.Net;
using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class ThirdPartyConnectionException : CommonException
    {
        public Exception MainException { get; set; }
        public ThirdPartyConnectionException(string lang, Exception ex, [CallerMemberName] string methodName = "default") : base(Messages.GetOperationFailedMessage("ارتباط با سرور", "server connection", lang), methodName,(short)HttpStatusCode.BadRequest)
        {
            MainException = ex;
        }
    }
}
