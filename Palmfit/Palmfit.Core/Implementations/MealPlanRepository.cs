using Palmfit.Core.Dtos;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.EntityEnums;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palmfit.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Palmfit.Core.Implementations
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly PalmfitDbContext _palmfitDbContext;

        public MealPlanRepository(PalmfitDbContext palmfitDbContext)
        {
            _palmfitDbContext = palmfitDbContext;
        }

        public async Task<string> AddMealPlan(PostMealDto postMealDto, string foodId)
        {
            var result = await _palmfitDbContext.Foods.FirstOrDefaultAsync(row => row.Id == foodId);


            if (result == null)
                return "not found";
           
            var MealToAdd = new MealPlan
            {
                Id = Guid.NewGuid().ToString(),
                MealOfDay = (MealOfDay)postMealDto.MealOfDay,
                DaysOfWeek = postMealDto.DaysOfWeek,
                FoodId = foodId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsDeleted = false,
            };
            await _palmfitDbContext.AddAsync(MealToAdd);
            _palmfitDbContext.SaveChanges();

            return "Food successfully added to Meal Plan!";

        }
    }
}

