 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;
using System.Security.Claims;

namespace Palmfit.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserCalorieDataController : ControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IUserCalorieDataRepository _userCalorieDataRepo;

		public UserCalorieDataController(UserManager<AppUser> userManager, IUserCalorieDataRepository userCalorieDataRepo)
		{
			_userManager = userManager;
			_userCalorieDataRepo = userCalorieDataRepo;
		}




		[HttpPost("add-user-calorie-data")]
		public async Task<IActionResult> AddUserCalorieData([FromBody] UserCalorieDataDto userCalorieDataDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ApiResponse.Failed(ModelState));
			}
			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var userExist = await _userManager.FindByIdAsync(userId);
				if (userExist == null)
				{
					return NotFound(ApiResponse.Failed("User not found"));
				}
				await _userCalorieDataRepo.AddUserCalorieDataAsync(userCalorieDataDto ,userId);
				return Ok(ApiResponse.Success("Calorie data added successfully"));

			}
			catch (Exception ex)
			{
				return BadRequest(ApiResponse.Failed(ex.Message));
			}
		}



		[HttpGet("get-user-data-by-id")]
		public async Task<IActionResult> GetUserCalorieDataById()
		{
			try
			{
				var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var userExist = await _userManager.FindByIdAsync(userId);

				if (userExist == null)
				{
					return NotFound(ApiResponse.Failed("User not found"));
				}

				var calorie = await _userCalorieDataRepo.GetUserCalorieDataByIdAsync(userId);
				if (calorie == null)
				{
					return NotFound(ApiResponse.Failed("No Calorie data has been added for this user"));
				}
				return Ok(ApiResponse.Success(calorie));
			}
			catch (Exception ex)
			{
				return BadRequest(ApiResponse.Failed(ex.Message));
			}
		}


	}
}
