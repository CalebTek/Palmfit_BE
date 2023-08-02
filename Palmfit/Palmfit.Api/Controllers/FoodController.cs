using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

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

        [HttpGet("get-meal-Id")]
        public async Task<IActionResult> GetFoodById(string Id)
        {
            try
            {
                var meal = await _food.GetFoodById(Id);

                if (meal == null)
                {
                    return NotFound(new { message = "Meal not found" });
                }

                var mealDto = new FoodDto
                {
                    Name = meal.Name,
                    Description = meal.Description,
                    Image = meal.Image
                };

                return Ok(mealDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
