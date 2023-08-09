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



       
        [HttpGet("subscription-status")]
        public async Task<IActionResult> GetSubscriptionStatus()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user =  await _userManager.FindByIdAsync(userId);
                var availableSubscription = await _subscriptionRepo.GetUserSubscriptionStatusAsync(userId);

                if(user == null)
                {
                    return NotFound(ApiResponse.Success("User not found."));
                }

                if (availableSubscription != null)
                {
                    return Ok(ApiResponse.Success(availableSubscription));
                }
                else
                {
                    return NotFound(ApiResponse.Success("User has no Subscription."));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(null, "An error occurred while fetching subscription status.", new List<string> { ex.Message }));
            }
        }








    }
}

