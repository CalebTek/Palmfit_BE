using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Controllers
{
    [Route("api/MealPlanController")]
    [ApiController]
    public class MealPlanController : ControllerBase
    {
        private readonly IMealPlanRepository _repository;
        public MealPlanController(IMealPlanRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add-MealPlan")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMealPlan([FromBody]FoodClassDTO foodClassDTO)
        {
            var createMealResponse = _repository.AddMealPlan(foodClassDTO);

            if (foodClassDTO == null)
            {
                return BadRequest(ApiResponse.Failed(foodClassDTO));
            }

            //return Ok();
            //return CreatedAtAction("GetMealPlan", foodClassDTO);
            return Ok(ApiResponse.Success(foodClassDTO));
        }
    }
}
