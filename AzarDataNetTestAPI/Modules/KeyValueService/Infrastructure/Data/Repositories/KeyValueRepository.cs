using AzarDataNetTestAPI.Modules.Common.Domain.Interfaces.Repositories;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories.Common;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Entities;
using AzarDataNetTestAPI.Modules.KeyValueService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzarDataNetTestAPI.Modules.KeyValueService.Infrastructure.Data.Repositories
{
    public class KeyValueRepository : BaseRepository<KeyValueEntity> , IKeyValueRepository
    {

        public KeyValueRepository(IDatabaseContext databaseContext, IHostApplicationLifetime hostApplicationLifetime,IHttpContextAccessor httpContextAccessor) : base(databaseContext, hostApplicationLifetime, httpContextAccessor)
        {

        }

        public async Task<KeyValueEntity> GetByKeyAsync(string Key)
        {
            return await _databaseContext.KeyValuesEntity.Where(k => k.Key == Key).FirstOrDefaultAsync();
        }

    }
}
