using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.EntityEnums;
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



		public async Task<IEnumerable<MealPlanDto>> GetWeeklyPlan(int week, string appUserId)
		{
			try
			{
				var data = await _palmfitDbContext.MealPlans.Where(row => row.Week == week && row.AppUserId == appUserId).Include(prop => prop.Food).ToListAsync();

				if (!data.Any())
				{
					return null;
				}

				List<MealPlanDto> result = new List<MealPlanDto>();
				foreach (var row in data)
				{
					MealPlanDto weeklyMeals = new MealPlanDto()
					{
						Name = row.Food.Name,
						Description = row.Food.Description,
						Details = row.Food.Details,
						Image = row.Food.Image,
						Calorie = row.Food.Calorie,
						Unit = Convert.ToString(row.Food.Unit),
						MealOfDay = Convert.ToString((MealOfDay)row.MealOfDay),
						DayOfTheWeek = Convert.ToString((DaysOfWeek)row.DayOfTheWeek),
						Week = row.Week

					};

					result.Add(weeklyMeals);
				}

				return result;
			}
			catch (Exception ex)
			{
			 throw new Exception(ex.Message);
			}
			
		}


		public async Task<IEnumerable<MealPlanDto>> GetDailyPlan(int day, string appUserId)
		{
			try
			{
				var data = await _palmfitDbContext.MealPlans.Where(x => (int)x.DayOfTheWeek == day && x.AppUserId == appUserId).Include(prop => prop.Food).ToListAsync();

				if (data.Count() == 0)
					return null;

				List<MealPlanDto> result = new();
				foreach (var item in data)
				{
					MealPlanDto dailyMealPlan = new MealPlanDto()
					{
						Name = item.Food.Name,
						Description = item.Food.Description,
						Details = item.Food.Details,
						Origin = item.Food.Origin,
						Image = item.Food.Image,
						Calorie = item.Food.Calorie,
						Unit = Convert.ToString(item.Food.Unit),
						MealOfDay = Convert.ToString((MealOfDay)item.MealOfDay),
						DayOfTheWeek = Convert.ToString((DaysOfWeek)item.DayOfTheWeek),
						Week = item.Week
					};

					result.Add(dailyMealPlan);
				}

				return result;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			
		}
	}
}
