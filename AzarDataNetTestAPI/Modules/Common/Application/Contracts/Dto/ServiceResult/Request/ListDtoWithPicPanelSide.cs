using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;

namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.ServiceResult.Request
{
    //TODO: move this class and related classes like this to request folder
    public class ListDtoWithPicPanelSide<T> : PanelIdentityDto<T>, IPicDetailDto
    {
        public int page { get; set; } = 1;
        public short pageSize { get; set; } = 50;
        public List<short> Heights { get; set; } = new List<short> { 200 };
        public List<short> Widths { get; set; } = new List<short> { 200 };
        public List<byte> Qualities { get; set; } = new List<byte> { 90 };
    }
}
