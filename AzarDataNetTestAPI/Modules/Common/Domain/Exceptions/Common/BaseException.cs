using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;

namespace AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common
{
    // this class is defined to identify my exceptions and predefined eception in asp
    public class BaseException : Exception
    {
        public PanelIdentityDto<long> PanelIdentityDto;
        public short StatusCode;
        public BaseException(string message, PanelIdentityDto<long> panelIdentityDto,short statusCode) : base(message)
        {
            PanelIdentityDto = panelIdentityDto;
            StatusCode = statusCode;
        }
        public BaseException(string message, Exception? innerException, PanelIdentityDto<long> panelIdentityDto) : base(message, innerException)
        {
            PanelIdentityDto = panelIdentityDto;
        }
    }
}
