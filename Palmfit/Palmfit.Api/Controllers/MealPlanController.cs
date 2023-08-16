using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;

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
        public async Task<IActionResult> AddMealPlan([FromBody] PostMealDto postMealDto, string foodId)
        {
            if (postMealDto == null || foodId == null)
            {
                return BadRequest(ApiResponse.Failed("Invalid Input"));
            }

            var result = await _repository.AddMealPlan(postMealDto, foodId);

            if (result == "not found")
                return NotFound();

            return Ok(ApiResponse.Success(postMealDto));
        }
    }
}
