using System.Net;
using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class NotFoundException : CommonException
    {
        public NotFoundException(string EntityName, string EnglishEntityName, string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetEntityNotFoundMessage(EntityName, EnglishEntityName, lang), methodName,(short)HttpStatusCode.NotFound)
        {

        }
    }
}
