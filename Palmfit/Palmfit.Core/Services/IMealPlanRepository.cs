using Palmfit.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IMealPlanRepository
    {
        //public string AddMealPlan(PostMealDto postMealDto, string foodId, string userId);
        Task<string> AddMealPlan(PostMealDto postMealDto, string foodId, string userId);
    }
}
