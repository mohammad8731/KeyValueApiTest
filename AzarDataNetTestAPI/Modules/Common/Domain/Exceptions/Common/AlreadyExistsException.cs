using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class AlreadyExistsException : CommonException
    {
        public AlreadyExistsException(string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetAlreadyExistsMessage(lang), methodName)
        {

        }
    }
}
