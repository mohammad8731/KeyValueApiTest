using System.Net;
using System.Runtime.CompilerServices;
using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Static;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class FileIOException : BaseException
    {
        public Exception MainException { get; set; }
        public string MethodName { get; set; }
        public FileIOException(string EntityName, string EnglishEntityName, string lang, Exception mainException, PanelIdentityDto<long> panelIdentityDto = null, [CallerMemberName] string methodName = "default") : base(Messages.GetOperationFailedMessage(EntityName, EnglishEntityName, lang), panelIdentityDto,(short)HttpStatusCode.BadRequest)
        {
            MainException = mainException;
            MethodName = methodName;
        }
    }
}
