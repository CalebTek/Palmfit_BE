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
                // Seed data for FoodClasses
                foodClasses = new List<FoodClass>
                {
                    new FoodClass
                    {
                        Name = "Beverages",
                        Description = "Beverage class description",
                        Details = "Details about beverage class",
                    },
                    new FoodClass
                    {
                        Name = "Breakfast Cereals",
                        Description = "Breakfast cereals class description",
                        Details = "Details about breakfast cereals class",
                    },
                    new FoodClass
                    {
                        Name = "Fish",
                        Description = "Fish class description",
                        Details = "Details about fish class",
                    },
                    new FoodClass
                    {
                        Name = "Fruits",
                        Description = "Fruits class description",
                        Details = "Details about fruits class",
                    },
                    new FoodClass
                    {
                        Name = "Grains and Pasta",
                        Description = "Grains and pasta class description",
                        Details = "Details about grains and pasta class",
                    },
                    new FoodClass
                    {
                        Name = "Meats",
                        Description = "Meats class description",
                        Details = "Details about meats class",
                    },
                    new FoodClass
                    {
                        Name = "Nuts and Seeds",
                        Description = "Nuts and seeds class description",
                        Details = "Details about nuts and seeds class",
                    },
                    new FoodClass
                    {
                        Name = "Snacks",
                        Description = "Snacks class description",
                        Details = "Details about snacks class",
                    },
                    new FoodClass
                    {
                        Name = "Soups and Sauces",
                        Description = "Soups and sauces class description",
                        Details = "Details about soups and sauces class",
                    },
                    // Add more food classes as needed
                };

                

               


                //foodClasses = new List<FoodClass>
                //{
                //    new FoodClass
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Grains",
                //        Description = "Foods from grains",
                //        Details = "Foods derived from various grains",
                //        IsDeleted = false
                //    },
                //    new FoodClass
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Vegetables",
                //        Description = "Various types of vegetables",
                //        Details = "Different vegetables with unique nutritional profiles",
                //        IsDeleted = false
                //    },
                //    new FoodClass
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Fruits",
                //        Description = "Assorted fruits",
                //        Details = "Fresh and juicy fruits from around the world",
                //        IsDeleted = false
                //    },
                //    new FoodClass
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Dairy",
                //        Description = "Milk and milk-based products",
                //        Details = "Good source of calcium",
                //        IsDeleted = false
                //    }

                //    // Add more food classes here
                //};

                context.FoodClasses.AddRange(foodClasses);
                await context.SaveChangesAsync();
            }

            if (!context.Foods.Any())
            {
                // Seed data for Foods
                var foods = new List<Food>
            {
                // Foods for Beverages
                new Food
                {
                    Name = "Coffee Instant With Whitener Reduced Calorie",
                    Description = "Description of coffee",
                    Details = "Details about coffee",
                    Origin = "Origin of coffee",
                    Image = "coffee.jpg",
                    Calorie = 509,
                    Carbs = 59.94M,
                    Proteins = 1.96M,
                    Fats = 29.1M,
                    Unit = UnitType.Grams,
                    FoodClass = foodClasses[0],
                },
                new Food
                {
                    Name = "Kraft Coffee Instant French Vanilla Cafe",
                    Description = "Description of French Vanilla Cafe",
                    Details = "Details about French Vanilla Cafe",
                    Origin = "Origin of French Vanilla Cafe",
                    Image = "french_vanilla_cafe.jpg",
                    Calorie = 481,
                    Carbs = 74.6M,
                    Proteins = 2.5M,
                    Fats = 19.2M,
                    Unit = UnitType.Grams,
                    FoodClass = foodClasses[0],
                },
                // Continue adding more foods for each class
            };
                //var foods = new List<Food>
                //{
                //    new Food
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Apple",
                //        Description = "A sweet and crunchy fruit",
                //        Details = "Rich in fiber and vitamin C",
                //        Origin = "United States",
                //        Image = "apple.jpg",
                //        Calorie = 52.0m,
                //        Unit = UnitType.Pound,
                //        FoodClassId = foodClasses[0].Id,
                //        IsDeleted = false
                //    },
                //    new Food
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Banana",
                //        Description = "A yellow fruit with a smooth texture",
                //        Details = "Good source of potassium",
                //        Origin = "Philippines",
                //        Image = "banana.jpg",
                //        Calorie = 96.0m,
                //        Unit = UnitType.Ounce,
                //        FoodClassId = foodClasses[3].Id,
                //        IsDeleted = false
                //    },
                //    new Food
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Carrot",
                //        Description = "An orange vegetable",
                //        Details = "Rich in beta-carotene",
                //        Origin = "China",
                //        Image = "carrot.jpg",
                //        Calorie = 41.0m,
                //        Unit = UnitType.Tablespoon,
                //        FoodClassId = foodClasses[1].Id,
                //        IsDeleted = false
                //    },
                //    new Food
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Milk",
                //        Description = "Fresh cow's milk",
                //        Details = "Good source of calcium and vitamin D",
                //        Origin = "United States",
                //        Image = "milk.jpg",
                //        Calorie = 42.0m,
                //        Unit = UnitType.Cup,
                //        FoodClassId = foodClasses[2].Id,
                //        IsDeleted = false
                //    },
                //    new Food
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Rice",
                //        Description = "White Rice",
                //        Details =
                //            "Rice is a cereal grain that is a primary source of carbohydrates for many cultures around the world. It comes in various varieties, including white rice, brown rice, and more.",
                //        Origin = "Asia, particularly in countries like China, India, and Japan.",
                //        Image = "rice.jpg",
                //        Unit = UnitType.Cup,
                //        Calorie = 130,
                //        FoodClassId = foodClasses[0].Id,
                //        IsDeleted = false
                //    },
                //    new Food
                //    {
                //        Id = Guid.NewGuid().ToString(),
                //        Name = "Broccoli",
                //        Description = "Fresh Broccoli",
                //        Details =
                //            "Broccoli is known for its high nutritional value, being rich in vitamins, minerals, and fiber. It is often consumed cooked or as part of salads and stir-fries.",
                //        Origin = "Mediterranean region, specifically Italy.",
                //        Image = "broccoli.jpg",
                //        Unit = UnitType.Pound,
                //        Calorie = 55,
                //        FoodClassId = foodClasses[2].Id,
                //        IsDeleted = false
                //    },
                //    // Add more foods here
                //};

                context.Foods.AddRange(foods);
                await context.SaveChangesAsync();
            }
        }
    }
}