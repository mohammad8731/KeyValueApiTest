using System.ComponentModel.DataAnnotations;

namespace AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Common
{
    public class EntityId<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
