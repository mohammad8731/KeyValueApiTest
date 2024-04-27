using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories.Common;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Entities;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Domain.Interfaces.Repositories
{
    // we apply interface in repository implementation for open closed principle and dependency inversion principle
    public interface IKeyValueRepository : IBaseRepository<KeyValueEntity>
    {
        // add specific database operation here that is not in base interface
        Task<KeyValueEntity> GetByKeyAsync(string Key);
    }
}
