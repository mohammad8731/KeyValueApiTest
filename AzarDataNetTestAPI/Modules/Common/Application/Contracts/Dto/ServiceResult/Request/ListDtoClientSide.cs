using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;

namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.ServiceResult.Request
{
    public class ListDtoClientSide : IdentityDto<int>
    {
        public int page { get; set; } = 1;
        public short pageSize { get; set; } = 50;

    }
}
