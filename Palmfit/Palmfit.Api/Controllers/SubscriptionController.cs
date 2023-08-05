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



        [HttpPost("create")]
        public async Task<IActionResult> CreateSubscription([FromBody] CreateSubscriptionDto subscriptionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse.Failed("Invalid subscription data."));
            }
             
            // Ensuring the user exists
            var user = await _userManager.FindByIdAsync(subscriptionDto.AppUserId);
            if (user == null)
            {
                return NotFound(ApiResponse.Failed("User not found."));
                
            }

            var createdSubscription = await _subscriptionRepo.CreateSubscriptionAsync(subscriptionDto);
            if (createdSubscription != null)
            {
                return Ok(ApiResponse.Success("Subscription created successfully."));
            }
            else
            {
                return BadRequest(ApiResponse.Failed("Subscription creation failed."));
            }
        }

        



    }
}

