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

        [HttpGet("Get-User-status/{id}")]
        public async Task<IActionResult> GetUserStatus(string id)
        {
            if (id == null) return BadRequest(ApiResponse.Failed(id, "Invalid Id"));

            var result = await _user.GetUserStatus(id);

            if(result == null) return NotFound(ApiResponse.Failed(result));

            return Ok(ApiResponse.Success(result));
        }
    }
}
