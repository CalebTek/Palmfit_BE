using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        //api-to-updatefood
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood(string id, UpdateFoodDto foodDto)
        {
            var updatedfood = await _food.UpdateFoodAsync(id, foodDto);
            if (updatedfood == "Food not found.")
                return NotFound(ApiResponse.Failed(updatedfood));
            else if(updatedfood == "Food failed to update.")
            {
                return BadRequest(ApiResponse.Failed(updatedfood));
            }

            return Ok(ApiResponse.Success(updatedfood));
        }
    }
}
