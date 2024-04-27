namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.DtoExample
{
    public class PanelIdentityDtoExample<T> : IdentityDtoExample<T>
    {
        public virtual byte RoleId { get; set; } = 2;
        public virtual int RoleAccountId { get; set; } = 0;
    }
}
