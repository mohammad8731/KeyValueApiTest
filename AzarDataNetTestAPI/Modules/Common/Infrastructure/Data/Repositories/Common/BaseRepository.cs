using AzarDataNetTestAPI.Modules.Common.Domain.Interfaces.Repositories;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories.Common
{
    public class BaseRepository
    {
        public readonly IDatabaseContext _databaseContext;
        public readonly IHostApplicationLifetime _hostApplicationLifetime;

        public BaseRepository(IDatabaseContext databaseContext, IHostApplicationLifetime hostApplicationLifetime)
        {
            _databaseContext = databaseContext;
            _hostApplicationLifetime = hostApplicationLifetime;
        }
        public async Task SaveChangesAsync()
        {
            await _databaseContext.SaveChangesAsync(_hostApplicationLifetime.ApplicationStopping);
        }
        public void Attach<T>(T entity) where T : class
        {
            _databaseContext.Attach(entity);
        }
    }
}
