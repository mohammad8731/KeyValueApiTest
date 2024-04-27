using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    public class CommonException : BaseException
    {
        public string MethodCallerName { get; set; }
        public CommonException(string message, string methodName, PanelIdentityDto<long> panelIdentityDto = null) : base(message, panelIdentityDto)
        {
            MethodCallerName = methodName;
        }
    }
}
