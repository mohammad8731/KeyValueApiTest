namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request
{
    // we use this inerface to add PanelIdentityDto as a <has a relation> in dtos so creating dto for calling a service in an other service has less cost ,
    // since 8 properties don't need to be copied any more and just a pointer is set in other dtos need to be made 
    public interface IPanelIdentityDto<T>
    {
        public PanelIdentityDto<T> PanelIdentityDto { get; set; }
    }
}
