using System.Text.Json.Serialization;

namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Common
{
    public class EntityTime<T> : EntityId<T>
    {
        [JsonIgnore]
        public virtual DateTime LastInsert { get; set; } = DateTime.Now;
        [JsonIgnore]
        public virtual DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
