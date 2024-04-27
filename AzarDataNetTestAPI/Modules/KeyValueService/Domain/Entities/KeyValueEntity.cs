using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Common;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Domain.Entities
{
    public class KeyValueEntity : EntityId<int>
    {
        // key will be unique since we want to update a value of a certain key and remove value of a certain key ,
        // so we don't have several values for the key
        // key is index to have unique value
        public string Key { get; set; }
        // store value as json 
        public string Value { get; set; } 

    }
}
