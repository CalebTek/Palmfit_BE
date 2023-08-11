using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Implementations;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Palmfit.Data.EntityEnums;
using Palmfit.Core.Services;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodInterfaceRepository _food;
        private readonly PalmfitDbContext _db;

        public FoodController(IFoodInterfaceRepository foodInterfaceRepository, PalmfitDbContext db)
        {
            _food = foodInterfaceRepository;
            _db = db;
        }



        [HttpGet("get-all-meals")]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetAllFoods()
        {
            //Getting all food from database
            var foods = await _food.GetAllFoodAsync();
            if (!foods.Any())
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

        [HttpGet("get-meal-Id")]
        public async Task<IActionResult> GetFoodById(string Id)
        {
            
            {
                var meal = await _food.GetFoodById(Id);

                if (meal == null)
                {
                    return NotFound(ApiResponse.Failed("Meal not found"));
                }

                var mealDto = new FoodDto
                {
                    Name = meal.Name,
                    Description = meal.Description,
                    Image = meal.Image
                };

                return Ok(ApiResponse.Success( mealDto));
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


        [HttpPost("add-food")]
        public async Task<ActionResult<ApiResponse<Food>>> AddFood(FoodDto foodDto)
        {
            try
            {
                // Check if FoodClass needs to be added
                FoodClass foodClass = null;
                if (foodDto.FoodClass != null)
                {
                    foodClass = new FoodClass
                    {
                        Name = foodDto.FoodClass.Name,
                        Description = foodDto.FoodClass.Description,
                        Details = foodDto.FoodClass.Details
                    };

                    // Add the new FoodClass to the database
                    await _food.AddFoodClassAsync(foodClass);
                }

                // Convert the FoodDto to the Food entity
                var food = new Food
                {
                    Name = foodDto.Name,
                    Description = foodDto.Description,
                    Details = foodDto.Details,
                    Origin = foodDto.Origin,
                    Image = foodDto.Image,
                    Calorie = foodDto.Calorie,
                    Unit = foodDto.Unit,
                    FoodClass = foodClass,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                // Add the new food to the database
                await _food.AddFoodAsync(food);

                return ApiResponse<Food>.Success(food, "Food added successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<Food>.Failed(null, ex.Message);
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






        [HttpDelete("{id}/Delete-Food-byId")]
        public async Task<ActionResult<ApiResponse>> DeleteAsync([FromRoute] string id)
        {

            var targetedFood = await _food.GetFoodByIdAsync(id);

            if (targetedFood == null)
            {
           
                return NotFound(ApiResponse.Failed("Food not found"));   // Provide a response indicating Failed deletion if food does not exist
            }

            else
            {
                await _food.DeleteAsync(id);
                return ApiResponse.Success("Food deleted Successfully");     // Provide a response indicating successful deletion
            }
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
