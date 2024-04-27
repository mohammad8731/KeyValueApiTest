using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Common;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Domain.Entities
{
    public class KeyValueEntiity : EntityId<int>
    {
        public string Key { get; set; }
    }
}
