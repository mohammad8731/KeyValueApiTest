namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.DtoExample
{
    public class ListDtoPanelSideExample<T>
    {
        public int page { get; set; } = 1;
        public short pageSize { get; set; } = 50;
        public byte RoleId { get; set; } = 2;
        public int RoleAccountId { get; set; } = 0;
    }
}
