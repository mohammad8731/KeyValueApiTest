using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class SmsEmailException : BaseException
    {
        public string MethodName { get; set; }
        public SmsEmailException(string Message, string methodName, PanelIdentityDto<long> panelIdentityDto = null) : base(Message, panelIdentityDto)
        {
            MethodName = methodName;
        }
    }
}
