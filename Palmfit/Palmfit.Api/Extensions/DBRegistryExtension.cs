using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Services.Client.AccountManagement;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;
using Palmfit.Core.Dtos;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;


namespace Palmfit.Api.Extensions
{
    public static class DBRegistryExtension
    {
        public static void AddDbContextAndConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContextPool<PalmfitDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                //options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
         
            });

<<<<<<< HEAD
            // Cloudinary registration -------------------------------------
            var cloudinarySettings = new CloudinarySettings();
            configuration.GetSection("Cloudinary").Bind(cloudinarySettings);

            var cloudinaryAccount = new CloudinaryDotNet.Account(
                cloudinarySettings.CloudName,
                cloudinarySettings.ApiKey,
                cloudinarySettings.ApiSecret
            );
            var cloudinary = new Cloudinary(cloudinaryAccount);
            services.AddSingleton(cloudinary);
            // Cloudinary registration ends --------------------------------
=======
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });

            // ...
>>>>>>> 3155de66307ede536232a2df1dd4ec7fbe1b5e35

            services.AddScoped<IFoodInterfaceRepository, FoodInterfaceRepository>();
            services.AddScoped<IUserInterfaceRepository, UserInterfaceRepository>();
            services.AddScoped<IReferralRepository, ReferralRepository>();

            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

			// Configure JWT authentication options-------------------------------------------
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

            //Password configuration
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
            });

            // Repo Registration
            services.AddScoped<IFoodInterfaceRepository, FoodInterfaceRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
<<<<<<< HEAD
            services.AddScoped<IFileUploadRepository, FileUploadRepository>();
=======
            services.AddScoped<IInviteRepository, InviteRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();

            services.AddScoped<IMealPlanRepository, MealPlanRepository>();
            services.AddScoped<IUserInterfaceRepository, UserInterfaceRepository>();
            services.AddScoped<IReferralRepository, ReferralRepository>();
>>>>>>> 3155de66307ede536232a2df1dd4ec7fbe1b5e35


            // Identity role registration with Stores and default token provider
            services.AddIdentity<AppUser, AppUserRole>()
                .AddEntityFrameworkStores<PalmfitDbContext>()
                .AddDefaultTokenProviders();

            /* <-------Start-------- Seed the database using DbContext ------- Start------>*/

            //services.AddScoped<SeedData>();

            // Call the seed method after the DbContext is created
            //services.AddScoped<IServiceProvider>(provider =>
            //{

            //});

            /* <-------End-------- Seed the database using DbContext ------- End------>*/
        }
    }
}