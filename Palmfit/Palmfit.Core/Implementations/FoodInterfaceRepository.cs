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
        public async Task<String> UpdateFoodClass(string foodClassId, FoodClassDto updatedFoodClassDto)
        {
            try
            {
                var foodClassEntity = await _db.FoodClasses.FindAsync(foodClassId);
                if (foodClassEntity == null)
                {
                    return "Food with ID does not exist";
                }
                foodClassEntity.Name = updatedFoodClassDto.Name;
                foodClassEntity.Description = updatedFoodClassDto.Description;
                foodClassEntity.Details = updatedFoodClassDto.Details;

                await _db.SaveChangesAsync();
                var updatedFoodClassDtoResponse = new FoodClassDto
                {
                    Name = foodClassEntity.Name,
                    Description = foodClassEntity.Description,
                    Details = foodClassEntity.Details,
                };
                return "Food class updated successfully.";
            }
            catch (Exception ex)
            {
                return "Failed to update food class.";
            }
        }
    }
}