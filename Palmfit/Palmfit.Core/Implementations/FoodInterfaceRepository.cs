using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;
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
       
 
        private readonly PalmfitDbContext _dbContext;

        public FoodInterfaceRepository(PalmfitDbContext dbContext)
        {
           _dbContext = dbContext;
        }
		
		public async Task<List<Food>> GetAllFoodAsync() 
        {
            return await _dbContext.Foods.ToListAsync();
        }

        
        public async Task<Food> GetFoodById(string id)
        {
            return await _dbContext.Foods.FirstOrDefaultAsync(f => f.Id == id);
        }



        public async Task AddFoodAsync(Food food)
        {
            // Generate a new GUID for the Food entity
            food.Id = Guid.NewGuid().ToString();

            // Add the new food to the database
            await _dbContext.Foods.AddAsync(food);
            await _dbContext.SaveChangesAsync();
        }


        /* < Start----- required methods to Calculate Calorie -----Start > */

        private decimal ConvertToGrams(decimal amount, UnitType unit)
        {
            switch (unit)
            {
                case UnitType.Tablespoon:
                    return amount * 14.3m;
                case UnitType.Ounce:
                    return amount * 28.4m;
                case UnitType.Cup:
                    return amount * 340m;
                case UnitType.Pound:
                    return amount * 453.592m;
                default:
                    throw new ArgumentException("Invalid unit type.", nameof(unit));
            }
        }

        public async Task<decimal> GetCalorieByNameAsync(string foodName, UnitType unit, decimal amount)
        {
            var food = await _dbContext.Foods.FirstOrDefaultAsync(f => f.Name == foodName);
            if (food == null)
                throw new ArgumentException("Food not found with the specified name.", nameof(foodName));

            decimal convertedAmount = ConvertToGrams(amount, unit);
            return food.Calorie * convertedAmount;
        }

        public async Task<decimal> GetCalorieByIdAsync(string foodId, UnitType unit, decimal amount)
        {
            var food = await _dbContext.Foods.FirstOrDefaultAsync(f => f.Id == foodId);
            if (food == null)
                throw new ArgumentException("Food not found with the specified ID.", nameof(foodId));

            decimal convertedAmount = ConvertToGrams(amount, unit);
            return food.Calorie * convertedAmount;
        }

        public async Task<decimal> CalculateTotalCalorieAsync(Dictionary<string, (UnitType unit, decimal amount)> foodNameAmountMap)
        {
            decimal totalCalorie = 0;

            foreach (var kvp in foodNameAmountMap)
            {
                var food = await _dbContext.Foods.FirstOrDefaultAsync(f => f.Name == kvp.Key);
                if (food == null)
                    throw new ArgumentException($"Food not found with the specified Name: {kvp.Key}", nameof(foodNameAmountMap));

                decimal convertedAmount = ConvertToGrams(kvp.Value.amount, kvp.Value.unit);
                totalCalorie += food.Calorie * convertedAmount;
            }

            return totalCalorie;
        }

        public async Task<IEnumerable<Food>> GetFoodsByNameAsync(string foodName)
        {
            return await _dbContext.Foods.Where(f => f.Name == foodName).ToListAsync();
        }

        public async Task<IEnumerable<Food>> GetFoodsByIdAsync(string foodId)
        {
            return await _dbContext.Foods.Where(f => f.Id == foodId).ToListAsync();
        }

        /* < End----- required methods to Calculate Calorie -----End > */

        public async Task<string> UpdateFoodAsync(string id, UpdateFoodDto foodDto)
        {
            var food = await _dbContext.Foods.FindAsync(id);

            if (food == null)
                return "Food not found.";

            food.Name = foodDto.Name;
            food.Description = foodDto.Description;
            food.Details = foodDto.Details;
            food.Origin = foodDto.Origin;
            food.Image = foodDto.Image;
            food.Calorie = foodDto.Calorie;

            // Convert the string value to UnitType enum
            if (Enum.TryParse(foodDto.Unit, out UnitType unitType))
            {
                food.Unit = unitType;
            }
            else
            {
                return "Invalid unit type.";
            }

            food.FoodClassId = foodDto.FoodClassId;

            try
            {
				await _dbContext.SaveChangesAsync();
                return "Food updated successfully.";
            }
            catch (Exception)
            {
                return "Food failed to update.";
            }
        }


        public async Task AddFoodClassAsync(FoodClass foodClass)
        {
            // Generate a new GUID for the FoodClass entity
            foodClass.Id = Guid.NewGuid().ToString();

            // Add the new FoodClass to the database
            await _dbContext.FoodClasses.AddAsync(foodClass);
            await _dbContext.SaveChangesAsync();
        }



        //get food list by category
        public async Task<ICollection<FoodDto>> GetFoodByCategory(string id)
        {

            var getFoodData = await _dbContext.Foods.Where(x => x.FoodClassId == id).ToListAsync();
            if (getFoodData.Count() == 0 )
                return null;

            List<FoodDto> result = new();

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
        
        public async Task<string> DeleteAsync(string id)
        {
            var existingFood = await _dbContext.Foods.FirstOrDefaultAsync(x => x.Id == id);
            if (existingFood == null)
            {
                return $"Food with Id: {id} cannot be found";
            }
            _dbContext.Foods.Remove(existingFood);
            await _dbContext.SaveChangesAsync();
            return "Successfully deleted";
        }

        public async Task<Food> GetFoodByIdAsync(string id)
        {
            var food = await _dbContext.Foods.FirstOrDefaultAsync(x => x.Id == id);

            if (food == null) return null;
            return food;
        }
    }
}
