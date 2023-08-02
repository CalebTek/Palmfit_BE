using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System.Data.Entity;
using System.Text;

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

            // Configure JWT authentication options-----------------------
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            //jwt configuration ends-------------



            //Repo Registration
            services.AddScoped<IFoodInterfaceRepository, FoodInterfaceRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();


            //Identity role registration with Stores and default token provider
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<PalmfitDbContext>()
                .AddDefaultTokenProviders();


            /* <-------Start-------- Seed the database using DbContext ------- Start------>*/

            services.AddScoped<SeedData>();

            // Call the seed method after the DbContext is created
            services.AddScoped<IServiceProvider>(provider =>
            {
                var dbContext = provider.GetRequiredService<PalmfitDbContext>();
                SeedData.Initialize(dbContext);
                return provider;
            });

            /* <-------End-------- Seed the database using DbContext ------- End------>*/

        }
    }
}
