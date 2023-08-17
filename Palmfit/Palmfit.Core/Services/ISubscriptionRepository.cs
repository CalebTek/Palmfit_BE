using System;
using System.Collections.Generic;
using System.Linq;
using Palmfit.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Palmfit.Data.Entities;

namespace Palmfit.Core.Services
{
    public interface ISubscriptionRepository
    {
        Task<Subscription> GetSubscriptionByIdAsync(string subscriptionId);
        Task<IEnumerable<Subscription>> GetSubscriptionsByUserIdAsync(string userId);
        Task<IEnumerable<Subscription>> GetSubscriptionsByUserNameAsync(string userName);
        Task<Subscription> CreateSubscriptionAsync(CreateSubscriptionDto subscriptionDto, ClaimsPrincipal loggedInUser);
        Task<bool> DeleteSubscriptionAsync(string subscriptionId);
        Task<string> UpdateSubscriptionAsync(SubscriptionDto subscriptionDto);
        Task<Subscription> GetUserSubscriptionStatusAsync(string userId);
	}
}
