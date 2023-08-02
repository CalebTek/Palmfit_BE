﻿using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
     
    public interface IFoodInterfaceRepository 
    {
        Task<List<Food>> GetAllFoodAsync();

        /* < Start----- required methods to Calculate Calorie -----Start > */
        Task<decimal> GetCalorieByNameAsync(string foodName, UnitType unit, decimal amount);
        Task<decimal> GetCalorieByIdAsync(string foodId, UnitType unit, decimal amount);
        Task<decimal> CalculateTotalCalorieAsync(Dictionary<string, (UnitType unit, decimal amount)> foodNameAmountMap);
        Task<IEnumerable<Food>> GetFoodsByNameAsync(string foodName);
        Task<IEnumerable<Food>> GetFoodsByIdAsync(string foodId);

        /* < End----- required methods to Calculate Calorie -----End > */



        Task<ICollection<FoodDto>> GetFoodByCategory(string id);
       
    }
}
