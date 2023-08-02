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

        //public async Task<FoodDto> AddFood(FoodDto food)//Argument
        //{

        //    bool doesFoodExist = await _db.Foods.AnyAsync(x => x.Name == food.Name && x.Description == food.Description && x.Origin == food.Origin && x.FoodClassId == food.FoodClass);

        //    if (doesFoodExist)
        //        return null;

        //    Food data = new()
        //    {
        //        Name = food.Name,
        //        Description = food.Description, 
        //        Origin = food.Origin,   
        //        Details = food.Details,
        //        Image = food.Image,
        //        Calorie = food.Calorie,
        //        Unit = food.Unit,
        //        FoodClassId = food.FoodClass,
        //        CreatedAt = DateTime.Now
        //    };

        //    var addToDb = await _db.AddAsync(data);
        //    var result = _db.SaveChanges();
        //    if (result < 1)
        //        return null;

        //    return food;

        //}

    }
}
