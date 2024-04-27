using System.Net;
using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class ExpiredException : CommonException
    {
        public ExpiredException(string prop, string englishProp, string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetExpiredMessage(prop, englishProp, lang), methodName,(short)HttpStatusCode.BadRequest)
        {

        }
    }
}
