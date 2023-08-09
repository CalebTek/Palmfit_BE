using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpDelete("/subscription")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteSubscription(string subscriptionId)
        {
            try
            {
                var result = await _subscriptionRepository.DeleteSubscriptionAsync(subscriptionId);

                if (!result)
                    return ApiResponse<bool>.Failed(false, "Subscription not found");

                return ApiResponse<bool>.Success(true, "Subscription deleted");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Failed(false, ex.Message);
            }
        }
    }
}
