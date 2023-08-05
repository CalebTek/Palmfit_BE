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

        public async Task<Food> GetFoodByIdAsync(string id)
        {
            return await _db.Foods.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<string> DeleteAsync(string id)
        {
           
            var existingFood = await GetFoodByIdAsync(id);
            if (existingFood == null)
            {
                return $"Food with Id: {id} cannot be found";
            }
            _db.Foods.Remove(existingFood);
            await _db.SaveChangesAsync();
            return "Successfully deleted";
        }
    }
 }
