using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodInterfaceRepository _food;

        public FoodController(IFoodInterfaceRepository foodInterfaceRepository)
        {
            _food = foodInterfaceRepository;
        }



        [HttpGet("get-all-meals")]

        public async Task<ActionResult<IEnumerable<FoodDto>>> GetAllFoods()
        {
            //Getting all food from database
            var foods = await _food.GetAllFoodAsync();

            if(foods.Count() <= 0)
            {
                var res = await _food.GetAllFoodAsync();
                return NotFound(ApiResponse.Failed(res));
            }
            else
            {
                var result = await _food.GetAllFoodAsync();

                return (Ok(ApiResponse.Success(result)));
            }
        }

        /* < Start----- required methods to Calculate Calorie -----Start > */

        [HttpGet("calculate-calorie-by-name")]
        public async Task<ActionResult<ApiResponse<decimal>>> CalculateCalorieForFoodByName(string foodName, UnitType unit, decimal amount)
        {
            try
            {
                decimal calorie = await _food.GetCalorieByNameAsync(foodName, unit, amount);
                return ApiResponse<decimal>.Success(calorie, "Calorie calculation successful");
            }
            catch (ArgumentException ex)
            {
                return ApiResponse<decimal>.Failed(0, ex.Message);
            }
        }

        [HttpGet("calculate-total-calorie")]
        public async Task<ActionResult<ApiResponse<decimal>>> CalculateTotalCalorieForSelectedFoods([FromQuery] Dictionary<string, (UnitType unit, decimal amount)> foodNameAmountMap)
        {
            if (foodNameAmountMap == null || !foodNameAmountMap.Any())
            {
                return ApiResponse<decimal>.Failed(0, "Food IDs and units dictionary cannot be empty.");
            }

            try
            {
                decimal totalCalorie = await _food.CalculateTotalCalorieAsync(foodNameAmountMap);
                return ApiResponse<decimal>.Success(totalCalorie, "Total calorie calculation successful");
            }
            catch (ArgumentException ex)
            {
                return ApiResponse<decimal>.Failed(0, ex.Message);
            }
        }

        /* < End----- required methods to Calculate Calorie -----End > */
    }
}
