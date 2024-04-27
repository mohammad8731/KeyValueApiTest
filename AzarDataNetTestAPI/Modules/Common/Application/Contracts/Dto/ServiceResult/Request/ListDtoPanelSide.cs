using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;

namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.ServiceResult.Request
{
    public class ListDtoPanelSide<T> : PanelIdentityDto<T>
    {
        public int page { get; set; } = 1;
        public short pageSize { get; set; } = 50;
    }
}
