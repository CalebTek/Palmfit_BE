using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;

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


    }
}
