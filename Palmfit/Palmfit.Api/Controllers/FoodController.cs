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

            var createdFoodClass = await _foodInterfaceRepository.CreateFoodClass(foodClassDto);

            if (createdFoodClass == null)
            {
                return NotFound(ApiResponse.Failed(createdFoodClass));
            }
            return Ok(ApiResponse.Success(createdFoodClass));
        }
    }
}
