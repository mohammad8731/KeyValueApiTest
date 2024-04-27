using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Languages;

namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request
{
    public class IdentityParentDto : Language
    {

        // type of user requesting
        public string Entity { get; set; }

        // id of user  requesting
        public int EntityId { get; set; }

        //: panelRole duty is : to initialize entity,entityId and isClientSide in requestDtoInitializer
        public bool IsClientSide { get; set; }


        // type of service from that we are calling servicelocalquery 
        //public Type ServiceName { get; set; } = null;//:// by ServiceName , id, entity,entityId and isClientSide we check if the info we want is accessable

        public byte ServiceTypeName { get; set; } //:// by ServiceName , id, entity,entityId and isClientSide we check if the info we want is accessable
    }
}
