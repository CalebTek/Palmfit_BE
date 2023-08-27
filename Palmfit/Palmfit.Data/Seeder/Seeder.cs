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
                        Id = Guid.NewGuid().ToString(),
                        Name = "Beverages",
                        Description = "Refreshing liquid options, including teas, juices, and drinks.",
                        Details = " A diverse range of beverages, from energizing coffee to hydrating fruit juices.",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Breakfast Cereals",
                        Description = "Quick and nutritious morning choices, often paired with milk or yogurt.",
                        Details = "Cereals offer a variety of textures and flavors, packed with vitamins and minerals.",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Fish",
                        Description = "Nutrient-rich seafood, from mild to flavorful options.",
                        Details = "Fish provides lean protein, omega-3s, and versatility in cooking styles.",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Fruits",
                        Description = "Natural, sweet delights in various forms and flavors.",
                        Details = "Fruits offer vitamins, fiber, and antioxidants, perfect for snacks and desserts.",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Grains and Pasta",
                        Description = "Staple foods like rice, grains, and pasta, suitable for many dishes.",
                        Details = "Grains provide energy and are versatile foundations for diverse meals.",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    },
                    new FoodClass
                    {
                       Id = Guid.NewGuid().ToString(),
                        Name = "Meats",
                        Description = "Protein sources from different animals, ideal for hearty meals.",
                        Details = "Meats offer protein variety, cooked to tender perfection in various recipes.",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Nuts and Seeds",
                        Description = " Nutrient-dense snacks, rich in healthy fats and proteins.",
                        Details = " Nuts and seeds offer satisfying crunch and valuable nutrients.",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Snacks",
                        Description = "Quick bites for satisfying cravings, in sweet and savory forms.",
                        Details = " Snacks range from crispy chips to guilt-free popcorn, perfect for anytime munching.",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                    },
                    new FoodClass
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Soups and Sauces",
                        Description = "Flavor boosters like soups and sauces, enhancing meals.",
                        Details = " Soups provide comfort, while sauces add depth and flavor to dishes.",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
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
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[0].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
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
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[0].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                // Additional foods for Beverages
                new Food
                {
                    Name = "Apple Juice",
                    Description = "Description of apple juice",
                    Details = "Details about apple juice",
                    Origin = "Origin of apple juice",
                    Image = "apple_juice.jpg",
                    Calorie = 110,
                    Carbs = 28.97M,
                    Proteins = 0.25M,
                    Fats = 0.28M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[0].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Orange Juice",
                    Description = "Description of orange juice",
                    Details = "Details about orange juice",
                    Origin = "Origin of orange juice",
                    Image = "orange_juice.jpg",
                    Calorie = 112,
                    Carbs = 25.79M,
                    Proteins = 1.74M,
                    Fats = 0.21M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[0].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Green Tea",
                    Description = "Description of green tea",
                    Details = "Details about green tea",
                    Origin = "Origin of green tea",
                    Image = "green_tea.jpg",
                    Calorie = 2,
                    Carbs = 0.47M,
                    Proteins = 0.02M,
                    Fats = 0.05M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[0].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },

                // Additional foods for Breakfast Cereals
                new Food
                {
                    Name = "Corn Flakes",
                    Description = "Description of corn flakes",
                    Details = "Details about corn flakes",
                    Origin = "Origin of corn flakes",
                    Image = "corn_flakes.jpg",
                    Calorie = 126,
                    Carbs = 28.97M,
                    Proteins = 1.9M,
                    Fats = 0.2M,
                    Unit = UnitType.Ounce,
                    FoodClassId = foodClasses[1].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Oatmeal",
                    Description = "Description of oatmeal",
                    Details = "Details about oatmeal",
                    Origin = "Origin of oatmeal",
                    Image = "oatmeal.jpg",
                    Calorie = 71,
                    Carbs = 12.12M,
                    Proteins = 2.41M,
                    Fats = 1.42M,
                    Unit = UnitType.Ounce,
                    FoodClass = foodClasses[1],
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Granola",
                    Description = "Description of granola",
                    Details = "Details about granola",
                    Origin = "Origin of granola",
                    Image = "granola.jpg",
                    Calorie = 499,
                    Carbs = 64.11M,
                    Proteins = 9.44M,
                    Fats = 22.75M,
                    Unit = UnitType.Ounce,
                    FoodClassId = foodClasses[1].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                // Additional foods for Fish
                new Food
                {
                    Name = "Tuna Salad",
                    Description = "Description of tuna salad",
                    Details = "Details about tuna salad",
                    Origin = "Origin of tuna salad",
                    Image = "tuna_salad.jpg",
                    Calorie = 210,
                    Carbs = 4.1M,
                    Proteins = 20.3M,
                    Fats = 13.4M,
                    Unit = UnitType.Ounce,
                    FoodClassId = foodClasses[2].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Salmon Sushi",
                    Description = "Description of salmon sushi",
                    Details = "Details about salmon sushi",
                    Origin = "Origin of salmon sushi",
                    Image = "salmon_sushi.jpg",
                    Calorie = 304,
                    Carbs = 38.2M,
                    Proteins = 13.9M,
                    Fats = 10.9M,
                    Unit = UnitType.Piece,
                    FoodClassId = foodClasses[2].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Shrimp Scampi",
                    Description = "Description of shrimp scampi",
                    Details = "Details about shrimp scampi",
                    Origin = "Origin of shrimp scampi",
                    Image = "shrimp_scampi.jpg",
                    Calorie = 367,
                    Carbs = 5.4M,
                    Proteins = 21.8M,
                    Fats = 28.7M,
                    Unit = UnitType.Ounce,
                    FoodClassId = foodClasses[2].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },

                // Additional foods for Fruits
                new Food
                {
                    Name = "Pineapple",
                    Description = "Description of pineapple",
                    Details = "Details about pineapple",
                    Origin = "Origin of pineapple",
                    Image = "pineapple.jpg",
                    Calorie = 50,
                    Carbs = 13.12M,
                    Proteins = 0.54M,
                    Fats = 0.12M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[3].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Mango",
                    Description = "Description of mango",
                    Details = "Details about mango",
                    Origin = "Origin of mango",
                    Image = "mango.jpg",
                    Calorie = 150,
                    Carbs = 38.6M,
                    Proteins = 1.6M,
                    Fats = 0.6M,
                    Unit = UnitType.Piece,
                    FoodClassId = foodClasses[3].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Kiwi",
                    Description = "Description of kiwi",
                    Details = "Details about kiwi",
                    Origin = "Origin of kiwi",
                    Image = "kiwi.jpg",
                    Calorie = 61,
                    Carbs = 14.9M,
                    Proteins = 1.1M,
                    Fats = 0.5M,
                    Unit = UnitType.Piece,
                    FoodClass = foodClasses[3],
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },

                // Additional foods for Grains and Pasta
                new Food
                {
                    Name = "Brown Rice",
                    Description = "Description of brown rice",
                    Details = "Details about brown rice",
                    Origin = "Origin of brown rice",
                    Image = "brown_rice.jpg",
                    Calorie = 215,
                    Carbs = 45.8M,
                    Proteins = 5.0M,
                    Fats = 1.8M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[4].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Whole Wheat Bread",
                    Description = "Description of whole wheat bread",
                    Details = "Details about whole wheat bread",
                    Origin = "Origin of whole wheat bread",
                    Image = "whole_wheat_bread.jpg",
                    Calorie = 128,
                    Carbs = 25.2M,
                    Proteins = 5.6M,
                    Fats = 1.7M,
                    Unit = UnitType.Piece,
                    FoodClassId = foodClasses[4].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Quinoa",
                    Description = "Description of quinoa",
                    Details = "Details about quinoa",
                    Origin = "Origin of quinoa",
                    Image = "quinoa.jpg",
                    Calorie = 222,
                    Carbs = 39.4M,
                    Proteins = 4.1M,
                    Fats = 3.5M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[4].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },

                // Additional foods for Snacks
                new Food
                {
                    Name = "Popcorn (Air-Popped)",
                    Description = "Description of air-popped popcorn",
                    Details = "Details about air-popped popcorn",
                    Origin = "Origin of air-popped popcorn",
                    Image = "air_popped_popcorn.jpg",
                    Calorie = 31,
                    Carbs = 6.2M,
                    Proteins = 1.0M,
                    Fats = 0.4M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[5].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Trail Mix",
                    Description = "Description of trail mix",
                    Details = "Details about trail mix",
                    Origin = "Origin of trail mix",
                    Image = "trail_mix.jpg",
                    Calorie = 693,
                    Carbs = 60.5M,
                    Proteins = 14.1M,
                    Fats = 45.0M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[5].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Potato Chips",
                    Description = "Description of potato chips",
                    Details = "Details about potato chips",
                    Origin = "Origin of potato chips",
                    Image = "potato_chips.jpg",
                    Calorie = 152,
                    Carbs = 15.4M,
                    Proteins = 2.0M,
                    Fats = 9.8M,
                    Unit = UnitType.Ounce,
                    FoodClassId = foodClasses[5].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },

                // Additional foods for Beverages
                new Food
                {
                    Name = "Apple Cider",
                    Description = "Description of apple cider",
                    Details = "Details about apple cider",
                    Origin = "Origin of apple cider",
                    Image = "apple_cider.jpg",
                    Calorie = 117,
                    Carbs = 28.9M,
                    Proteins = 0.4M,
                    Fats = 0.2M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[0].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },

                // Additional foods for Breakfast Cereals
                new Food
                {
                    Name = "Oatmeal",
                    Description = "Description of oatmeal",
                    Details = "Details about oatmeal",
                    Origin = "Origin of oatmeal",
                    Image = "oatmeal.jpg",
                    Calorie = 147,
                    Carbs = 25.9M,
                    Proteins = 6.1M,
                    Fats = 2.2M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[1].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Granola Bars",
                    Description = "Description of granola bars",
                    Details = "Details about granola bars",
                    Origin = "Origin of granola bars",
                    Image = "granola_bars.jpg",
                    Calorie = 193,
                    Carbs = 38.4M,
                    Proteins = 2.7M,
                    Fats = 5.1M,
                    Unit = UnitType.Piece,
                    FoodClassId = foodClasses[1].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Raisin Bran Cereal",
                    Description = "Description of raisin bran cereal",
                    Details = "Details about raisin bran cereal",
                    Origin = "Origin of raisin bran cereal",
                    Image = "raisin_bran_cereal.jpg",
                    Calorie = 190,
                    Carbs = 46.8M,
                    Proteins = 4.7M,
                    Fats = 1.5M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[1].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },

                // Additional foods for Beverages
                new Food
                {
                    Name = "Cranberry Juice",
                    Description = "Description of cranberry juice",
                    Details = "Details about cranberry juice",
                    Origin = "Origin of cranberry juice",
                    Image = "cranberry_juice.jpg",
                    Calorie = 46,
                    Carbs = 12.2M,
                    Proteins = 0.4M,
                    Fats = 0.1M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[0].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Grape Juice",
                    Description = "Description of grape juice",
                    Details = "Details about grape juice",
                    Origin = "Origin of grape juice",
                    Image = "grape_juice.jpg",
                    Calorie = 152,
                    Carbs = 38.4M,
                    Proteins = 1.0M,
                    Fats = 0.3M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[0].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Mango Smoothie",
                    Description = "Description of mango smoothie",
                    Details = "Details about mango smoothie",
                    Origin = "Origin of mango smoothie",
                    Image = "mango_smoothie.jpg",
                    Calorie = 207,
                    Carbs = 51.9M,
                    Proteins = 1.4M,
                    Fats = 0.6M,
                    Unit = UnitType.Cup,
                    FoodClassId = foodClasses[0].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },

                // Additional foods for Fish
                new Food
                {
                    Name = "Trout Fillet",
                    Description = "Description of trout fillet",
                    Details = "Details about trout fillet",
                    Origin = "Origin of trout fillet",
                    Image = "trout_fillet.jpg",
                    Calorie = 168,
                    Carbs = 0.0M,
                    Proteins = 20.4M,
                    Fats = 9.0M,
                    Unit = UnitType.Ounce,
                    FoodClassId = foodClasses[2].Id,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Catfish Fillet",
                    Description = "Description of catfish fillet",
                    Details = "Details about catfish fillet",
                    Origin = "Origin of catfish fillet",
                    Image = "catfish_fillet.jpg",
                    Calorie = 105,
                    Carbs = 0.0M,
                    Proteins = 21.6M,
                    Fats = 2.4M,
                    Unit = UnitType.Ounce,
                    FoodClassId = foodClasses[2].Id, 
                    IsDeleted = false, 
                    CreatedAt = DateTime.Now,
                },
                new Food
                {
                    Name = "Halibut Steak",
                    Description = "Description of halibut steak",
                    Details = "Details about halibut steak",
                    Origin = "Origin of halibut steak",
                    Image = "halibut_steak.jpg",
                    Calorie = 119,
                    Carbs = 0.0M,
                    Proteins = 24.0M,
                    Fats = 2.0M,
                    Unit = UnitType.Ounce,
                    FoodClassId = foodClasses[2].Id, 
                    IsDeleted = false, 
                    CreatedAt = DateTime.Now,
                },
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