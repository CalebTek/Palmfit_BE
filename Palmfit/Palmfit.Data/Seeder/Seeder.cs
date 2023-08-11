using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;

namespace Palmfit.Data.Seeder
{
    public class Seeder
    {
        public static async Task SeedData(IApplicationBuilder app)
        {
            //Get db context
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PalmfitDbContext>();

            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {
                await context.Database.MigrateAsync();
            }

            var foodClasses = new List<FoodClass>();

            if (!context.FoodClasses.Any())
            {
                foodClasses = new List<FoodClass>
                {
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Grains",
                        Description = "Foods from grains",
                        Details = "Foods derived from various grains",
                        IsDeleted = false
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Vegetables",
                        Description = "Various types of vegetables",
                        Details = "Different vegetables with unique nutritional profiles",
                        IsDeleted = false
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Fruits",
                        Description = "Assorted fruits",
                        Details = "Fresh and juicy fruits from around the world",
                        IsDeleted = false
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Dairy",
                        Description = "Milk and milk-based products",
                        Details = "Good source of calcium",
                        IsDeleted = false
                    }

                    // Add more food classes here
                };

                context.FoodClasses.AddRange(foodClasses);
                await context.SaveChangesAsync();
            }

            if (!context.Foods.Any())
            {
                var foods = new List<Food>
                {
                    new Food
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Apple",
                        Description = "A sweet and crunchy fruit",
                        Details = "Rich in fiber and vitamin C",
                        Origin = "United States",
                        Image = "apple.jpg",
                        Calorie = 52.0m,
                        Unit = UnitType.Pound,
                        FoodClassId = foodClasses[0].Id,
                        IsDeleted = false
                    },
                    new Food
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Banana",
                        Description = "A yellow fruit with a smooth texture",
                        Details = "Good source of potassium",
                        Origin = "Philippines",
                        Image = "banana.jpg",
                        Calorie = 96.0m,
                        Unit = UnitType.Ounce,
                        FoodClassId = foodClasses[3].Id,
                        IsDeleted = false
                    },
                    new Food
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Carrot",
                        Description = "An orange vegetable",
                        Details = "Rich in beta-carotene",
                        Origin = "China",
                        Image = "carrot.jpg",
                        Calorie = 41.0m,
                        Unit = UnitType.Tablespoon,
                        FoodClassId = foodClasses[1].Id,
                        IsDeleted = false
                    },
                    new Food
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Milk",
                        Description = "Fresh cow's milk",
                        Details = "Good source of calcium and vitamin D",
                        Origin = "United States",
                        Image = "milk.jpg",
                        Calorie = 42.0m,
                        Unit = UnitType.Cup,
                        FoodClassId = foodClasses[2].Id,
                        IsDeleted = false
                    },
                    new Food
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Rice",
                        Description = "White Rice",
                        Details =
                            "Rice is a cereal grain that is a primary source of carbohydrates for many cultures around the world. It comes in various varieties, including white rice, brown rice, and more.",
                        Origin = "Asia, particularly in countries like China, India, and Japan.",
                        Image = "rice.jpg",
                        Unit = UnitType.Cup,
                        Calorie = 130,
                        FoodClassId = foodClasses[0].Id,
                        IsDeleted = false
                    },
                    new Food
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Broccoli",
                        Description = "Fresh Broccoli",
                        Details =
                            "Broccoli is known for its high nutritional value, being rich in vitamins, minerals, and fiber. It is often consumed cooked or as part of salads and stir-fries.",
                        Origin = "Mediterranean region, specifically Italy.",
                        Image = "broccoli.jpg",
                        Unit = UnitType.Pound,
                        Calorie = 55,
                        FoodClassId = foodClasses[2].Id,
                        IsDeleted = false
                    },
                    // Add more foods here
                };

                context.Foods.AddRange(foods);
                await context.SaveChangesAsync();
            }
        }
    }
}