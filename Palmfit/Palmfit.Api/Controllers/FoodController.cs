using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodInterfaceRepository _foodInterfaceRepository;

        public FoodController(IFoodInterfaceRepository foodInterfaceRepository)
        {
            _foodInterfaceRepository = foodInterfaceRepository;
        }

        [HttpPost("create-class-of-food")]
        public async Task<IActionResult> CreateFoodClass(FoodClassDto foodClassDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdFoodClass = await _foodInterfaceRepository.CreateFoodClass(foodClassDto);
                return Ok(createdFoodClass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the food class.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<FoodClassDto>>>> GetAllFoodClasses()
        {
            var response = await _foodInterfaceRepository.GetAllFoodClasses();
            return Ok(response);
        }

        [HttpDelete("{foodClassId}/delete-foodclass")]
        public async Task<ActionResult<ApiResponse<string>>> DeleteFoodClass(string foodClassId)
        {
            var response = await _foodInterfaceRepository.DeleteFoodClass(foodClassId);
            return Ok(response);
        }

        [HttpPut("{foodClassId}/update-foodclass")]
        public async Task<ActionResult<ApiResponse<FoodClassDto>>> UpdateFoodClass(string foodClassId, [FromBody] FoodClassDto updatedFoodClassDto)
        {
            var response = await _foodInterfaceRepository.UpdateFoodClass(foodClassId, updatedFoodClassDto);
            return Ok(response);
        }
    }
}
