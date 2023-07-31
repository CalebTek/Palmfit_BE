using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Services;
using Palmfit.Core.Dtos;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public RegisterController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] SignUpDto userRequest)
        {
            var res = await _userRepository.CreateUser(userRequest);
            if (res)
            {
                return Ok(ApiResponse.Success(res));
            }
            return BadRequest(ApiResponse.Failed(res));
            
        }
    }
}
