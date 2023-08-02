using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<string> UpdateFoodAsync(string id, UpdateFoodDto foodDto)
        {
            var food = await _db.Foods.FindAsync(id);

            if (food == null)
                return "Food not found.";

            food.Name = foodDto.Name;
            food.Description = foodDto.Description;
            food.Details = foodDto.Details;
            food.Origin = foodDto.Origin;
            food.Image = foodDto.Image;
            food.Calorie = foodDto.Calorie;
            food.Unit = foodDto.Unit;
            food.FoodClassId = foodDto.FoodClassId;

            try
            {
                await _db.SaveChangesAsync();
                return "Food updated successfully.";
            }
            catch (Exception)
            {
                return "Food failed to update.";
            }

        }
    }
}
