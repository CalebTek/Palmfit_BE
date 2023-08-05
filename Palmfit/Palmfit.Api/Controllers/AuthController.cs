﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

       
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration, IAuthRepository authRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _authRepo = authRepo;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>("Invalid request. Please provide a valid email and password."));
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(login.Email);

                if (user == null)
                {
                    return NotFound(new ApiResponse<string>("User not found. Please check your email and try again."));
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, lockoutOnFailure: false);

                if (!result.Succeeded)
                {
                    return Unauthorized(new ApiResponse<string>("Invalid credentials. Please check your email or password and try again."));
                }
                else
                {
                    var token = _authRepo.GenerateJwtToken(user);

                    // Returning the token in the response headers
                    Response.Headers.Add("Authorization", "Bearer " + token);

                    return Ok(new ApiResponse<string>("Login successful."));

                }
            }
        }


        [HttpPost("Validate-OTP")]
        public async Task<IActionResult> ValidateOTP([FromBody] OtpDto otpFromUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>("Invalid OTP, check and try again"));
            }
            var userOTP = await _authRepo.FindMatchingValidOTP(otpFromUser.Otp);
            if (userOTP == null)
            {
                return BadRequest(new ApiResponse<string>("Invalid OTP, check and try again"));
            }

            await _authRepo.UpdateVerifiedStatus(otpFromUser.Email);

            return Ok(new ApiResponse<string>("Validation Successfully."));
        }

        [HttpPost("Sign-Out")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Ok(ApiResponse.Success("Sign out successful"));
        }
    }
}
