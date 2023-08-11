using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
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
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepo = subscriptionRepo;
            _userManager = userManager;
            _subscriptionRepository = subscriptionRepository;
        }



        [HttpPost("create-subscription")]
        public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionDto subscriptionDto)
        [HttpDelete("/subscription")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteSubscription(string subscriptionId)
        {
            if (!ModelState.IsValid)
            try
            {
                return BadRequest(ApiResponse.Failed("Invalid subscription data."));
            }
            var loggedInUser = User.FindFirst(ClaimTypes.NameIdentifier);
                var result = await _subscriptionRepository.DeleteSubscriptionAsync(subscriptionId);

            // Ensuring the user exists
            var user = await _userManager.FindByIdAsync(loggedInUser.Value);
            if (user == null)
            {
                return NotFound(ApiResponse.Failed("User not found."));  
            }
                if (!result)
                    return ApiResponse<bool>.Failed(false, "Subscription not found");

            var createdSubscription = await _subscriptionRepo.CreateSubscriptionAsync(subscriptionDto, HttpContext.User );
            if (createdSubscription != null)
            {
                return Ok(ApiResponse.Success("Subscription created successfully."));
                return ApiResponse<bool>.Success(true, "Subscription deleted");
            }
            else
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed("Subscription creation failed."));
                return ApiResponse<bool>.Failed(false, ex.Message);
            }
        }

        

    }
}

