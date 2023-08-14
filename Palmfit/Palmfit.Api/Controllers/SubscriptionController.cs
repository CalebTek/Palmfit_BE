using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Implementations;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptionRepo;
        private readonly UserManager<AppUser> _userManager;

        public SubscriptionController(ISubscriptionRepository subscriptionRepo, UserManager<AppUser> userManager)
        {
            _subscriptionRepo = subscriptionRepo;
            _userManager = userManager;
        }



        [HttpPost("create-subscription")]
        public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionDto subscriptionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse.Failed("Invalid subscription data."));
            }
            var loggedInUser = User.FindFirst(ClaimTypes.NameIdentifier);

            // Ensuring the user exists
            var user = await _userManager.FindByIdAsync(loggedInUser.Value);
            if (user == null)
            {
                return NotFound(ApiResponse.Failed("User not found."));
            }

            var createdSubscription = await _subscriptionRepo.CreateSubscriptionAsync(subscriptionDto, HttpContext.User);
            if (createdSubscription != null)
            {
                return Ok(ApiResponse.Success("Subscription created successfully."));
            }
            else
            {
                return BadRequest(ApiResponse.Failed("Subscription creation failed."));
            }
        }

        [HttpDelete("/subscription")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteSubscription(string subscriptionId)
        {
            try
            {
                var result = await _subscriptionRepo.DeleteSubscriptionAsync(subscriptionId);

                if (!result)
                    return ApiResponse<bool>.Failed(false, "Subscription not found");

                return ApiResponse<bool>.Success(true, "Subscription deleted");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Failed(false, ex.Message);
            }
        }


		[HttpPut("update-subscription")]
		public async Task<IActionResult> UpdateSubscription([FromBody] SubscriptionDto subscriptionDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ApiResponse.Failed("Invalid subscription data."));
			}
			try
			{ 
				var message = await _subscriptionRepo.UpdateSubscriptionAsync(subscriptionDto);
				return Ok(ApiResponse.Success(message));
			}
			catch (Exception ex)
			{
				return BadRequest(ApiResponse.Failed("An error occurred while updating the subscription.", errors: new List<string> { ex.Message }));
			}
		}




	}
}