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


        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<FoodDto>>> DeleteAsync([FromRoute] string id)
        {

            var deletedFood = await _food.DeleteAsync(id);

            if (deletedFood == null)
            {
                var res = await _food.DeleteAsync(id);
                return NotFound(ApiResponse.Failed(res));   // Provide a response indicating Failed deletion if food does not exist
            }

            else
            {
                var result = await _food.DeleteAsync(id);
                return Ok(ApiResponse.Success(result));     // Provide a response indicating successful deletion
            }
        }


    }
}
