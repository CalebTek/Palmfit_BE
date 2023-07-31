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
        //prop
        private readonly IFoodInterfaceRepository _foodRepository;

        //ctor
        public FoodController(IFoodInterfaceRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        [HttpGet("foods-based-on-class")]
        public async Task<IActionResult> GetFoodsBasedOnClass(string id)
        {
            if (id == null) return BadRequest(ApiResponse.Failed(null, "Invalid id"));

            var result = await _foodRepository.GetFoodByCategory(id);

            if(result == null)
                return NotFound(ApiResponse.Failed(result));

            return Ok(ApiResponse.Success(result));


        }
    }
}
