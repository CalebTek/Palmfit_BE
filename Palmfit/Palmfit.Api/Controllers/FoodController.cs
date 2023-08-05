using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Implementations;
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

            if (foods.Count() <= 0)
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

        [HttpPut("{foodClassId}/update-foodclass")]
        public async Task<ActionResult<ApiResponse<FoodClassDto>>> UpdateFoodClass(string foodClassId, [FromBody] FoodClassDto updatedFoodClassDto)
        {
            var response = await _food.UpdateFoodClass(foodClassId, updatedFoodClassDto);
            if(response == null)
            {
                return BadRequest(ApiResponse.Failed(response));
            }
            return Ok(ApiResponse.Success(response));
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

        [HttpGet("foods-based-on-class")]
        public async Task<IActionResult> GetFoodsBasedOnClass(string id)
        {
            if (id == null) return BadRequest(ApiResponse.Failed(null, "Invalid id"));

            var result = await _food.GetFoodByCategory(id);

            if(result == null)
                return NotFound(ApiResponse.Failed(result));

            return Ok(ApiResponse.Success(result));
        }

        //api-to-updatefood
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(string id, UpdateFoodDto foodDto)
        {
            var updatedfood = await _food.UpdateFoodAsync(id, foodDto);
            if (updatedfood == "Food not found.")
                return NotFound(ApiResponse.Failed(updatedfood));
            else if (updatedfood == "Food failed to update.")
            {
                return BadRequest(ApiResponse.Failed(updatedfood));
            }

            return Ok(ApiResponse.Success(updatedfood));
        }
    }
}
