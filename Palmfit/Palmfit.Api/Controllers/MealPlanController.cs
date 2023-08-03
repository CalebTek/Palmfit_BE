using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
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
        public async Task<IActionResult> AddMealPlan([FromBody] PostMealDto postMealDto, string foodId, string userId)
        {
            var createMealResponse = _repository.AddMealPlan(postMealDto,foodId,userId);

            if (postMealDto == null || foodId == null || userId == null)
            {
                return BadRequest(ApiResponse.Failed(postMealDto));
            }

            var result = await _repository.AddMealPlan(postMealDto,foodId, userId);

            if (result == "not found")
                return NotFound();

            return Ok(ApiResponse.Success(postMealDto));
        }
    }
}
