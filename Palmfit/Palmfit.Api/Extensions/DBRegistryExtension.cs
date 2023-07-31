using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;

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

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
            });

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<PalmfitDbContext>()
            .AddDefaultTokenProviders();

        }
    }
}