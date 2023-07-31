using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("SearchByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Food>>> SearchFoodByName(string name)
        {
            var food = await _food.SearchFoodByName(name);

            if (food == null || food.Count == 0)
            {
                return NotFound(ApiResponse.Failed(new List<Food>(), "No matching food items found."));
            }

            return Ok(ApiResponse.Success(food));
        }

        [HttpGet("SearchByCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<FoodClass>>> SearchFoodByCategory(string category)
        {
            var searchResults = await _food.SearchFoodByCategory(category);
            if (searchResults == null || searchResults.Count == 0)
            {
                return NotFound(ApiResponse.Failed(new List<Food>(), "No matching food items found."));
            }

            return Ok(ApiResponse.Success(searchResults));
        }
    }
}
