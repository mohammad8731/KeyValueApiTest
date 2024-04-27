using System.Net;
using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class NotValidRoleException : CommonException
    {
        public NotValidRoleException(string lang, [CallerMemberName] string methodName = "default") : base(Messages.GetNotValidMessage("نقش وارد شده ", "role entered", lang), methodName,(short)HttpStatusCode.BadRequest)
        {

        }
    }
}

