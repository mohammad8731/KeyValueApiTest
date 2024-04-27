using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Database;
using AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configurations.DbContextConfig
{
    public static class DbContextConfig
    {
        public static void AddDBContext(this IServiceCollection services, IConfiguration _Configuration)
        {
            services.AddDbContextPool<DatabaseContext>(optionBuilder =>
            {
                //optionBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FootballManagement;Trusted_Connection=True;MultipleActiveResultSets=true");
                optionBuilder.UseSqlServer(DatabaseConfig.DbConnection).EnableSensitiveDataLogging();
            });
        }
    }
}
