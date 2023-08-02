using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;
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
            var food = await _db.Foods.FirstOrDefaultAsync(f => f.Name == foodName);
            if (food == null)
                throw new ArgumentException("Food not found with the specified name.", nameof(foodName));

            decimal convertedAmount = ConvertToGrams(amount, unit);
            return food.Calorie * convertedAmount;
        }

        public async Task<decimal> GetCalorieByIdAsync(string foodId, UnitType unit, decimal amount)
        {
            var food = await _db.Foods.FirstOrDefaultAsync(f => f.Id == foodId);
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
                var food = await _db.Foods.FirstOrDefaultAsync(f => f.Name == kvp.Key);
                if (food == null)
                    throw new ArgumentException($"Food not found with the specified Name: {kvp.Key}", nameof(foodNameAmountMap));

                decimal convertedAmount = ConvertToGrams(kvp.Value.amount, kvp.Value.unit);
                totalCalorie += food.Calorie * convertedAmount;
            }

            return totalCalorie;
        }

        public async Task<IEnumerable<Food>> GetFoodsByNameAsync(string foodName)
        {
            return await _db.Foods.Where(f => f.Name == foodName).ToListAsync();
        }

        public async Task<IEnumerable<Food>> GetFoodsByIdAsync(string foodId)
        {
            return await _db.Foods.Where(f => f.Id == foodId).ToListAsync();
        }

        /* < End----- required methods to Calculate Calorie -----End > */
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
