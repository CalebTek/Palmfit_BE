using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;

namespace Palmfit.Api.Controllers
{
    [Route("api/MealPlanController")]
    [ApiController]
    public class MealPlanController : ControllerBase
    {
        private readonly IMealPlanRepository _repository;
        public MealPlanController(IMealPlanRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add-MealPlan")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMealPlan([FromBody] PostMealDto postMealDto, string foodId)
        {
            if (postMealDto == null || foodId == null)
            {
                return BadRequest(ApiResponse.Failed("Invalid Input"));
            }

            var result = await _repository.AddMealPlan(postMealDto, foodId);

            if (result == "not found")
                return NotFound();

            return Ok(ApiResponse.Success(postMealDto));
        }


		[HttpGet("daily-meal-plan")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetDailyMealPlan(int day, string appUserId, int week)
		{
			if (day < 0 && day > 6 || appUserId == null)
				return BadRequest("wrong parameter entry!");

			var result = await _repository.GetDailyPlan(day, appUserId, week);

			if (result == null)
			{
				return NotFound(new ApiResponse<string>("meal plan not found!"));
			}
			return Ok(ApiResponse.Success(result));
		}


		[HttpGet("weekly-meal-plan")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetWeeklyPlan(int week, string appUserId)
		{

			if (week < 1 || week > 53 || appUserId == null)
			{
				return BadRequest(new ApiResponse<string>("wrong parameter entry!"));
			}

			var result = await _repository.GetWeeklyPlan(week, appUserId);
			if (result == null)
			{
				return NotFound(new ApiResponse<string>("meal plan not found!"));
			}

			return Ok(ApiResponse.Success(result));
		}
	}
}
