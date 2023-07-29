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
        
        private readonly PalmfitDbContext _palmfitDb;

        public FoodController(PalmfitDbContext palmfitDb)
        {
            _palmfitDb = palmfitDb;
        }

        [HttpGet("Get All Meals")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Food>> GetAllMeals()
        {      
            return Ok(_palmfitDb.Foods.ToList());
        }

    }
}
