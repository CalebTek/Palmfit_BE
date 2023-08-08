using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;

namespace Palmfit.Data.AppDbContext
{
    public class PalmfitDbContext : IdentityDbContext<AppUser, AppUserRole, string>
    {
        public DbSet<Health> Healths { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletHistory> WalletHistories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<FoodClass> FoodClasses { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<UserOTP> UserOTPs { get; set; }
        public DbSet<AppUserPermission> AppUserPermissions  { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUser> users { get; set; }


        public PalmfitDbContext(DbContextOptions<PalmfitDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure IdentityUserRole<string> as a keyless entity type
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

            // Configure One AppUser to Zero or One Relationships
            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Health)
                .WithOne(h => h.AppUser)
                .HasForeignKey<Health>(h => h.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Setting)
                .WithOne(s => s.AppUser)
                .HasForeignKey<Setting>(s => s.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Wallet)
                .WithOne(w => w.AppUser)
                .HasForeignKey<Wallet>(w => w.AppUserId);

            //Configure One AppUser to Many Relationships
            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.Invities)
                .WithOne(i => i.AppUser)
                .HasForeignKey(i => i.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.Notifications)
                .WithOne(n => n.AppUser)
                .HasForeignKey(n => n.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.Reviews)
                .WithOne(r => r.AppUser)
                .HasForeignKey(r => r.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.Subscriptions)
                .WithOne(s => s.AppUser)
                .HasForeignKey(s => s.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.AppUser)
                .HasForeignKey(t => t.AppUserId);

            // Configure One to One Health Relationship
            modelBuilder.Entity<Health>()
                .HasOne(h => h.AppUser)
                .WithOne(a => a.Health)
                .HasForeignKey<Health>(h => h.AppUserId);

            // Configure One to Zero or One Wallet Relationship
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.AppUser)
                .WithOne(a => a.Wallet)
                .HasForeignKey<Wallet>(w => w.AppUserId);

            // Configure One Wallet to Many Relationships
            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.AppUser);


            // Configure One to Many Transaction Relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.AppUser)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AppUserId);

            // Configure One to Many Subscription Relationship
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.AppUser)
                .WithMany(a => a.Subscriptions)
                .HasForeignKey(s => s.AppUserId);

            // Configure One to Many Reviews Relationships
            modelBuilder.Entity<Review>()
                .HasOne(r => r.AppUser)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AppUserId);

            // Configure One to Many Notification Relationship
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.AppUser)
                .WithMany(a => a.Notifications)
                .HasForeignKey(n => n.AppUserId);

            //Configure One to Many Invite Relationship
            modelBuilder.Entity<Invite>()
                .HasOne(i => i.AppUser)
                .WithMany(a => a.Invities)
                .HasForeignKey(i => i.AppUserId);

            //Configure One FoodClass to Many Relationship
            modelBuilder.Entity<FoodClass>()
                .HasMany(fc => fc.Foods)
                .WithOne(f => f.FoodClass)
                .HasForeignKey(f => f.FoodClassId);

            // Configure One to Many Foods Relationship
            modelBuilder.Entity<Food>()
                .HasOne(f => f.FoodClass)
                .WithMany(fc => fc.Foods)
                .HasForeignKey(f => f.FoodClassId);

            /* <-------Start-------- Configure Enum Mapping in DbContext ------- Start------>*/
            modelBuilder.Entity<Food>()
                .Property(f => f.Unit)
                .HasConversion<string>();

            /* <-------End-------- Configure Enum Mapping in DbContext ------- End------>*/

        }


    }

    /* <-------Start-------- Seed Data ------- Start------>*/
    // Seed FoodClass data
    public class SeedData
    {
        public static void Initialize(PalmfitDbContext context)
        {
            if (!context.FoodClasses.Any())
            {
                var foodClasses = new List<FoodClass>
            {
                new FoodClass {
                    Id = "1",
                    Name = "Grains", 
                    Description = "Foods from grains", 
                    Details = "Foods derived from various grains", 
                    IsDeleted = false },
                new FoodClass {
                    Id = "2",
                    Name = "Vegetables", 
                    Description = "Various types of vegetables", 
                    Details = "Different vegetables with unique nutritional profiles", 
                    IsDeleted = false },
                new FoodClass {
                    Id = "3",
                    Name = "Fruits", 
                    Description = "Assorted fruits", 
                    Details = "Fresh and juicy fruits from around the world", 
                    IsDeleted = false },
                new FoodClass {
                    Id = "4",
                    Name = "Dairy",
                    Description = "Milk and milk-based products",
                    Details = "Good source of calcium",
                    IsDeleted = false }

                // Add more food classes here
            };

                context.FoodClasses.AddRange(foodClasses);
                context.SaveChanges();
            }

            if (!context.Foods.Any())
            {
                var foods = new List<Food>
            {
                                    new Food
                {
                    Id = "1",
                    Name = "Apple",
                    Description = "A sweet and crunchy fruit",
                    Details = "Rich in fiber and vitamin C",
                    Origin = "United States",
                    Image = "apple.jpg",
                    Calorie = 52.0m,
                    Unit = UnitType.Pound,
                    FoodClassId = "1",
                    IsDeleted = false
                },
                new Food
                {
                    Id = "2",
                    Name = "Banana",
                    Description = "A yellow fruit with a smooth texture",
                    Details = "Good source of potassium",
                    Origin = "Philippines",
                    Image = "banana.jpg",
                    Calorie = 96.0m,
                    Unit = UnitType.Ounce,
                    FoodClassId = "1",
                    IsDeleted = false
                },
                new Food
                {
                    Id = "3",
                    Name = "Carrot",
                    Description = "An orange vegetable",
                    Details = "Rich in beta-carotene",
                    Origin = "China",
                    Image = "carrot.jpg",
                    Calorie = 41.0m,
                    Unit = UnitType.Tablespoon,
                    FoodClassId = "2",
                    IsDeleted = false
                },
                new Food
                {
                    Id = "4",
                    Name = "Milk",
                    Description = "Fresh cow's milk",
                    Details = "Good source of calcium and vitamin D",
                    Origin = "United States",
                    Image = "milk.jpg",
                    Calorie = 42.0m,
                    Unit = UnitType.Cup,
                    FoodClassId = "3",
                    IsDeleted = false
                },
                new Food
                {
                    Id = "5",
                    Name = "Rice",
                    Description = "White Rice",
                    Details = "Rice is a cereal grain that is a primary source of carbohydrates for many cultures around the world. It comes in various varieties, including white rice, brown rice, and more.",
                    Origin = "Asia, particularly in countries like China, India, and Japan.",
                    Image = "rice.jpg",
                    Unit = UnitType.Cup,
                    Calorie = 130,
                    FoodClassId = "1",
                    IsDeleted = false
                },
                new Food
                {
                    Name = "Broccoli",
                    Description = "Fresh Broccoli",
                    Details ="Broccoli is known for its high nutritional value, being rich in vitamins, minerals, and fiber. It is often consumed cooked or as part of salads and stir-fries.",
                    Origin = "Mediterranean region, specifically Italy.",
                    Image = "broccoli.jpg",
                    Unit = UnitType.Pound,
                    Calorie = 55,
                    FoodClassId = "2",
                    IsDeleted = false
                },
                // Add more foods here
            };

                context.Foods.AddRange(foods);
                context.SaveChanges();
            }
        }
    }
    /* <-------End-------- Seed Data ------- End------>*/

}