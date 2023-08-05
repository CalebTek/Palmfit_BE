using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Controllers
{
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        [HttpGet("get-subscription-by-id")]
        public async Task<ActionResult<ApiResponse<Subscription>>> GetSubscriptionById(string subscriptionId)
        {
            try
            {
                var subscription = await _subscriptionRepository.GetSubscriptionByIdAsync(subscriptionId);

                if (subscription == null)
                    return ApiResponse<Subscription>.Failed(null, "Subscription not found");

                return ApiResponse<Subscription>.Success(subscription, "Subscription found");
            }
            catch (Exception ex)
            {
                return ApiResponse<Subscription>.Failed(null, ex.Message);
            }
        }

        [HttpGet("get-subscriptions-by-user")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Subscription>>>> GetSubscriptionsByUser(string userId)
        {
            try
            {
                var subscriptions = await _subscriptionRepository.GetSubscriptionsByUserIdAsync(userId);

                if (!subscriptions.Any())
                    return ApiResponse<IEnumerable<Subscription>>.Failed(null, "Subscriptions not found");

                return ApiResponse<IEnumerable<Subscription>>.Success(subscriptions, "Subscriptions found");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Subscription>>.Failed(null, ex.Message);
            }
        }

        [HttpGet("get-subscriptions-by-username")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Subscription>>>> GetSubscriptionsByUsername(string userName)
        {
            try
            {
                var subscriptions = await _subscriptionRepository.GetSubscriptionsByUserNameAsync(userName);

                if (!subscriptions.Any())
                    return ApiResponse<IEnumerable<Subscription>>.Failed(null, "Subscriptions not found");

                return ApiResponse<IEnumerable<Subscription>>.Success(subscriptions, "Subscriptions found");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Subscription>>.Failed(null, ex.Message);
            }
        }
    }
}
