using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class WrongRoleException : CommonException
    {
        public WrongRoleException(string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetWrongRoleMessage(lang), methodName)
        {

        }
    }
}
