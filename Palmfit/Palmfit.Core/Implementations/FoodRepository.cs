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
    public class FoodRepository : IFoodRepository
    {
       


       
        private readonly PalmfitDbContext _dbContext;

        public FoodRepository(PalmfitDbContext dbContext)
        {
            _db = db;
           _dbContext = dbContext;
        }

        public async Task<List<Food>> GetAllFoodAsync()
		
		public async Task<List<Food>> GetAllFoodAsync() 
        {
            return await _dbContext.Foods.ToListAsync();
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

            var getFoodData = await _dbContext.Foods.Where(x => x.FoodClassId == id).ToListAsync();
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

		public async Task<FoodClass> GetFoodClassesByIdAsync(string foodClassId)
		{
			var res = new FoodClass();
			var foodClassInfo = await _dbContext.FoodClasses.FirstOrDefaultAsync(fc => fc.Id == foodClassId);
			if (foodClassInfo != null)
			{
				return res;
			}
			return foodClassInfo;

		}

		public string DeleteFoodClass(string foodClassId)
		{
			var foodClass = _dbContext.FoodClasses.FirstOrDefault(fc => fc.Id == foodClassId);

			if (foodClass != null)
			{
				_dbContext.FoodClasses.Remove(foodClass);
				_dbContext.SaveChanges();

				return "Delete Successful";
			}

			return "Food class does not exist";
		}
	}
}

