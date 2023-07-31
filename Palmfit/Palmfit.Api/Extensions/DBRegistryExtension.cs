using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;

namespace Palmfit.Api.Extensions
{
    public static class DBRegistryExtension
    {
        public static void AddDbContextAndConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<PalmfitDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IFoodInterfaceRepository, FoodInterfaceRepository>();
        }
    }
}
