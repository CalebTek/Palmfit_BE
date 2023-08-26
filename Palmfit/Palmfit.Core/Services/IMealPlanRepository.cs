﻿using Palmfit.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
	public interface IMealPlanRepository
	{
		Task<IEnumerable<MealPlanDto>> GetWeeklyPlan(int week, string appUserId);
		Task<IEnumerable<MealPlanDto>> GetDailyPlan(int day, string appUserId, int week);
		Task<string> AddMealPlan(PostMealDto postMealDto, string foodId);
	}
}
