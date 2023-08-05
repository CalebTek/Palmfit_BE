using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterfaceRepository _user;

        public UserController(IUserInterfaceRepository userInterfaceRepository)
        {
            _user = userInterfaceRepository;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(string id, UserDto userDto)
        {
            var updateUser = await _user.UpdateUserAsync(id, userDto);
            if (updateUser == "User not found.")
                return NotFound(ApiResponse.Failed(updateUser));
            else if (updateUser == "User failed to update.")
            {
                return BadRequest(ApiResponse.Failed(updateUser));
            }

            return Ok(ApiResponse.Success(updateUser));
        }
    }
}
