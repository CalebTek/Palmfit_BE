﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
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
            services.AddScoped<IUserInterfaceRepository, IUserInterfaceRepository>();

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
            //Password configuration
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
            });



            //Repo Registration
            services.AddScoped<IFoodInterfaceRepository, FoodInterfaceRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();


            //Identity role registration with Stores and default token provider
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<PalmfitDbContext>()
                .AddDefaultTokenProviders();

        }
    }
}
