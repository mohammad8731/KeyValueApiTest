using System.Net;
using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class RequiredException : CommonException
    {
        public RequiredException(string EntityName, string EnglishEntityName, string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetMyRequiredMessage(EntityName, EnglishEntityName, lang), methodName,(short)HttpStatusCode.BadRequest)
        {

        }
    }
}
