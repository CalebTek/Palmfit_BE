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
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly PalmfitDbContext _palmfitDbContext;

        public MealPlanRepository(PalmfitDbContext palmfitDbContext)
        {
            _palmfitDbContext = palmfitDbContext;
        }

        public string AddMealPlan(FoodClassDTO foodClassDTO)
        {
            //Automapper
            var MealToAdd = new FoodClass
            {
                Name = foodClassDTO.Name,
                Description = foodClassDTO.Description,
                Details = foodClassDTO.Details,
                Day = foodClassDTO.Day,
                Foods = (ICollection<Food>)foodClassDTO.Foods,
                //Foods = foodClassDTO.Foods
            };
            var addToDb = _palmfitDbContext.FoodClasses.Add(MealToAdd);
            var result = _palmfitDbContext.SaveChanges();

            if (result > 0)
                return "Operation completed";

            return "Operation failed";

        }
    }
}
