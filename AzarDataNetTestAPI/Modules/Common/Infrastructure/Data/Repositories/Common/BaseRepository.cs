using AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common;
using AzarDataNetTestAPI.Modules.Common.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IDatabaseContext _databaseContext;
        protected readonly IHostApplicationLifetime _hostApplicationLifetime;
        protected DbSet<T> _dbSet;
        protected readonly string _serviceMessageLanguage;


        public BaseRepository(IDatabaseContext databaseContext, IHostApplicationLifetime hostApplicationLifetime,IHttpContextAccessor httpContextAccessor)
        {
            _databaseContext = databaseContext;
            _hostApplicationLifetime = hostApplicationLifetime;
            _serviceMessageLanguage =httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
            _dbSet = _databaseContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _databaseContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _databaseContext.SaveChangesAsync(_hostApplicationLifetime.ApplicationStopping);
            }
            catch (Exception ex)
            {
                throw new DBOperationFailedException("عملیات", "operation", _serviceMessageLanguage, ex);
            }
        }
        public void Attach<T>(T entity) where T : class
        {
            _databaseContext.Attach(entity);
        }

    }
}
