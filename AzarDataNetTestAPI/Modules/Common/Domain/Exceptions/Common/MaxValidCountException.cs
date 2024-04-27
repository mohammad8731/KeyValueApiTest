using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class MaxValidCountException : CommonException
    {
        public MaxValidCountException(string prop, string englishProp, string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetMaxValideCountMessage(prop, englishProp, lang), methodName)
        {

        }
    }
}
