using System.Data.Entity;
using AzarDataNetTestAPI.Modules.Common.Domain.Interfaces.Repositories;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories.Common;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Entities;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Interfaces.Repositories;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Infrastructure.Data.Repositories
{
    public class KeyValueRepository : BaseRepository<KeyValueEntity> , IKeyValueRepository
    {

        public KeyValueRepository(IDatabaseContext databaseContext, IHostApplicationLifetime hostApplicationLifetime) : base(databaseContext, hostApplicationLifetime)
        {

        }

        public Task<KeyValueEntity> GetByKeyAsync(string Key)
        {
            return _databaseContext.KeyValuesEntity.Where(k => k.Key == Key).FirstOrDefaultAsync();
        }

    }
}
