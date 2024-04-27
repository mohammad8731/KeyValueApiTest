using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class NotValidException : CommonException
    {
        public NotValidException(string EntityName, string EnglishEntityName, string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetNotValidMessage(EntityName, EnglishEntityName, lang), methodName)
        {

        }
    }
}
