﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;

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
        [HttpGet("get-all-User")]

        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
         
            var usersDto = await _user.GetAllUsersAsync();

            if (usersDto.Count() <= 0)
            {
                var res = await _user.GetAllUsersAsync();
                return NotFound(ApiResponse.Failed(res));
            }
            else
            { 
                var result = await _user.GetAllUsersAsync();

                return Ok(ApiResponse.Success(result));
            }
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