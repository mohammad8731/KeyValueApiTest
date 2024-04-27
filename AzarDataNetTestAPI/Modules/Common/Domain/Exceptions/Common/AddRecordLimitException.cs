using System.Net;
using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class AddRecordLimitException : CommonException
    {
        public AddRecordLimitException(string entityName, string englishEntityName, short count, string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetAddRecordLimitMessage(entityName, englishEntityName, count, lang), methodName, (short)HttpStatusCode.BadRequest)
        {

        }
    }
}
