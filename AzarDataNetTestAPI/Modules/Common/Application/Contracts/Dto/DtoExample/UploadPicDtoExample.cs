namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.DtoExample
{
    public class UploadPicDtoExample<T> : PanelIdentityDtoExample<T>
    {
        //[Range(200, 300, ErrorMessage = "ارتفاع عکس کاور مقداری بین 200 تا 300 را میگیرد")]
        public List<short> Heights { get; set; } = new List<short> { 200 };

        // [Range(200, 300, ErrorMessage = "عرض عکس کاور مقداری بین 200 تا 300 را میگیرد")]
        public List<short> Widths { get; set; } = new List<short> { 200 };

        // [Range(0 , 100 , ErrorMessage = "حداکثر مقدار کیفیت میتواند 100 باشد")]
        public List<byte> Qualities { get; set; } = new List<byte> { 90 };
    }
}
