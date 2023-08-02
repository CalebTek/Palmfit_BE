using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class FoodInterfaceRepository : IFoodInterfaceRepository
    {
       


       
        private readonly PalmfitDbContext _db;

        public FoodInterfaceRepository(PalmfitDbContext db)
        {
           _db = db;
        }

        public async Task<List<Food>> GetAllFoodAsync() 
        {
            return await _db.Foods.ToListAsync();
        }


        public async Task AddFoodAsync(Food food)
        {
            // Generate a new GUID for the Food entity
            food.Id = Guid.NewGuid().ToString();

            // Add the new food to the database
            await _db.Foods.AddAsync(food);
            await _db.SaveChangesAsync();
        }

        public async Task AddFoodClassAsync(FoodClass foodClass)
        {
            // Generate a new GUID for the FoodClass entity
            foodClass.Id = Guid.NewGuid().ToString();

            // Add the new FoodClass to the database
            await _db.FoodClasses.AddAsync(foodClass);
            await _db.SaveChangesAsync();
        }



        //get food list by category
        public async Task<ICollection<FoodDto>> GetFoodByCategory(string id)
        {

            var getFoodData = await _db.Foods.Where(x => x.FoodClassId == id).ToListAsync();
            if (getFoodData.Count() == 0 )
                return null;

            List<FoodDto> result = null;

            foreach (var food in getFoodData)
            {
                FoodDto newEntry = new()
                {
                    Name = food.Name,
                    Description = food.Description,
                    Details = food.Details,
                    Origin = food.Origin,
                    Image = food.Image,
                    Calorie = food.Calorie,
                    Unit = food.Unit,
                    FoodClassId = food.FoodClassId,
                };

                result.Add(newEntry);
            }

            return result;
        }

    }
}
