using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        
        private readonly Food _food;

        public FoodController(Food food)
        {
            _food = food;
        }

        [HttpGet("Get All Meals")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllMeals()
        {   
            if(_food == null)
            {
                throw new Exception("There are no food in the database");
            }
            return Ok(_food);
        }

    }
}
