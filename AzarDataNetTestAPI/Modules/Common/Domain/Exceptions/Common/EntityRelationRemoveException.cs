using System.Net;
using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class EntityRelationRemoveException : CommonException
    {
        public EntityRelationRemoveException(string EntityName, string EnglishEntityName, string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetEntityRelationRemoveMessage(EntityName, EnglishEntityName, lang), methodName,(short)HttpStatusCode.BadRequest)
        {

        }
    }
}
