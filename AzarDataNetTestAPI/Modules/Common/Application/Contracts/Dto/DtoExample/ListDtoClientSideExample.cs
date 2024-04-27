namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.DtoExample
{
    public class ListDtoClientSideExample<T> : IdentityDtoExample<T>
    {
        public int page { get; set; } = 1;
        public short pageSize { get; set; } = 50;
    }
}
