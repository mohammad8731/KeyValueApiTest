namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.ServiceResult.Request
{
    public class PicDetailDto : IPicDetailDto
    {
        public List<short> Heights { get; set; }
        public List<short> Widths { get; set; }
        public List<byte> Qualities { get; set; }
    }
}
