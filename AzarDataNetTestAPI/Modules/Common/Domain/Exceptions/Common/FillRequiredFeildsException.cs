using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class FillRequiredFeildsException : CommonException
    {
        public FillRequiredFeildsException(string lang, [CallerMemberName] string methodName = "default") : base(Messages.FillRequiredFeildsMessage(lang), methodName)
        {

        }
    }
}
