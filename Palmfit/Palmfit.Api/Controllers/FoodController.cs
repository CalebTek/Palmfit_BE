using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
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

        //[HttpPost]
        //[Route("FoodAdded")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status409Conflict)]
        //public async Task<IActionResult> AddFood([FromBody]FoodDto food)//Argument
        //{
        //    if (food==null)
        //        return BadRequest(ApiResponse.Failed(food));


        //    var result = await _food.AddFood(food);

        //    if (result == null)
        //        return BadRequest(ApiResponse.Failed(result));

        //    return Ok(ApiResponse.Success(result));



        //}
    }
}
