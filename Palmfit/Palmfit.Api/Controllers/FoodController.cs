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
        private readonly IFoodInterfaceRepository _foodRepo;

        public FoodController(IFoodInterfaceRepository foodInterfaceRepository)
        {
            _foodRepo = foodInterfaceRepository;
        }




        [HttpGet("get-all-meals")]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetAllFoods()
        {
            //Getting all food from database
            var foods = await _foodRepo.GetAllFoodAsync();

            if (foods.Count() <= 0)
            {
                var res = await _foodRepo.GetAllFoodAsync();
                return NotFound(ApiResponse.Failed(res));
            }
            else
            {
                var result = await _foodRepo.GetAllFoodAsync();

                return (Ok(ApiResponse.Success(result)));
            }
        }

        /* < Start----- required methods to Calculate Calorie -----Start > */

        [HttpGet("calculate-calorie-by-name")]
        public async Task<ActionResult<ApiResponse<decimal>>> CalculateCalorieForFoodByName(string foodName, UnitType unit, decimal amount)
        {
            try
            {
                decimal calorie = await _foodRepo.GetCalorieByNameAsync(foodName, unit, amount);
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
                decimal totalCalorie = await _foodRepo.CalculateTotalCalorieAsync(foodNameAmountMap);
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

            var result = await _foodRepo.GetFoodByCategory(id);

            if (result == null)
                return NotFound(ApiResponse.Failed(result));

            return Ok(ApiResponse.Success(result));
        }




        //api-to-updatefood
        [HttpPut("update-food")]
        public async Task<IActionResult> UpdateFood(string id, UpdateFoodDto foodDto)
        {
            var updatedfood = await _foodRepo.UpdateFoodAsync(id, foodDto);
            if (updatedfood == "Food not found.")
                return NotFound(ApiResponse.Failed(updatedfood));
            else if (updatedfood == "Food failed to update.")
            {
                return BadRequest(ApiResponse.Failed(updatedfood));
            }

            return Ok(ApiResponse.Success(updatedfood));
        }




        [HttpGet("Get-FoodClass-By-Id")]
        public async Task<ActionResult<ApiResponse<FoodClass>>> GetFoodClassById(string foodClassId)
        {
            try
            {
                var existingFoodClass = await _foodRepo.GetFoodClassesByIdAsync(foodClassId);

                if (existingFoodClass.Id == null)
                {
                    // Food class not found, return an error response
                    return ApiResponse<FoodClass>.Failed(data: null, message: "Food class not found");
                }

                // Return the food class as a success response
                return ApiResponse<FoodClass>.Success(existingFoodClass, message: "Food class retrieved successfully");
            }
            catch (Exception ex)
            {
                // If an exception occurs during the retrieval process, return an error response
                return ApiResponse<FoodClass>.Failed(data: null, message: "An error occurred while retrieving the food class.", errors: new List<string> { ex.Message });
            }
        }




		[HttpDelete("delete-foodclass")]
		public async Task<ActionResult<ApiResponse<string>>> DeleteFoodClass(string foodClassId)
		{
			try
			{
				var existingFoodClass = _foodRepo.DeleteFoodClass(foodClassId);

				if (existingFoodClass == "Food class does not exist")
				{
					// Food class not found, return an error response
					return ApiResponse<string>.Failed(data: null, message: "Food class not found");
				}

				_foodRepo.DeleteFoodClass(foodClassId);

				// Return a success response
				return ApiResponse<string>.Success(data: null, message: "Food class deleted successfully");
			}
			catch (Exception ex)
			{
				// If an exception occurs during the deletion process, return an error response
				return ApiResponse<string>.Failed(data: null, message: "An error occurred during food class deletion.", errors: new List<string> { ex.Message });
			}
		}





	}


}
 
	 