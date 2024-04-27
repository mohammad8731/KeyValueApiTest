using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Constants;

namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request
{
    public class PanelIdentityDto<T> : IdentityDto<T> , ICloneable
    {
        public byte RoleId { get; set; } = (byte)IConstants.EntityNameEnums.Admin;
        public int RoleAccountId { get; set; } = 0;

        public object Clone()
        {
            return new PanelIdentityDto<T>()
            {
                Entity = this.Entity,
                EntityId = this.EntityId,
                Id = this.Id,
                IsClientSide = this.IsClientSide,
                RequestLanguage = this.RequestLanguage,
                RoleAccountId = this.RoleAccountId,
                RoleId = this.RoleId,
                ServiceTypeName = this.ServiceTypeName
            };
        }
    }
}

