﻿using Palmfit.Core.Dtos;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface ISubscriptionRepository
    {
        Task<Subscription> CreateSubscriptionAsync(CreateSubscriptionDto subscriptionDto, ClaimsPrincipal loggedInUser);
        Task<bool> DeleteSubscriptionAsync(string subscriptionId);
        Task<Subscription> GetUserSubscriptionStatusAsync(string userId);
        Task<string> UpdateSubscriptionAsync(SubscriptionDto subscriptionDto);

	}
}
