using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Implementations;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _food;

        public FoodController(IFoodRepository foodInterfaceRepository)
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

		[HttpGet("{foodClassId}/Get-FoodClass-By-Id")]
		public async Task<ActionResult<ApiResponse<FoodClass>>> GetFoodClassById(string foodClassId)
		{
			try
			{
				var existingFoodClass = await _food.GetFoodClassesByIdAsync(foodClassId);

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

		[HttpDelete("{foodClassId}/delete-foodclass")]
		public async Task<ActionResult<ApiResponse<string>>> DeleteFoodClass(string foodClassId)
		{
			try
			{
				var existingFoodClass = _food.DeleteFoodClass(foodClassId);

				if (existingFoodClass == "Food class does not exist")
				{
					// Food class not found, return an error response
					return ApiResponse<string>.Failed(data: null, message: "Food class not found");
				}

				_food.DeleteFoodClass(foodClassId);

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
