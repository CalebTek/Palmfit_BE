using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly PalmfitDbContext _palmfitDb;

        public SubscriptionRepository(PalmfitDbContext palmfitDb)
        {
            _palmfitDb = palmfitDb;
        }

        public async Task<Subscription> CreateSubscriptionAsync(CreateSubscriptionDto subscriptionDto, ClaimsPrincipal loggedInUser)
        {
            var subscription = new Subscription
            {
                Id = Guid.NewGuid().ToString(),
                Type = subscriptionDto.Type,
                StartDate = subscriptionDto.StartDate,
                EndDate = subscriptionDto.EndDate,
                AppUserId = loggedInUser.FindFirst(ClaimTypes.NameIdentifier).Value
            };

            _palmfitDb.Subscriptions.Add(subscription);
            await _palmfitDb.SaveChangesAsync();

            return subscription;
        }


		public async Task<string> UpdateSubscriptionAsync(string subscriptionId, SubscriptionDto subscriptionDto)
		{
			string message = "";
			var subscription = await _palmfitDb.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriptionId);
			if (subscription == null)
			{
				message = "Subscription not found.";
			}
			else
			{
				subscription.Type = subscriptionDto.Type;
				subscription.StartDate = subscriptionDto.StartDate;
				subscription.EndDate = subscriptionDto.EndDate;
				subscription.IsExpired = subscriptionDto.IsExpired;
				subscription.UpdatedAt = DateTime.Now;

				await _palmfitDb.SaveChangesAsync();
				message = "Subscription updated successfully!";
			}
			return message;
		}

		public Task<string> UpdateSubscriptionAsync(SubscriptionDto subscriptionDto)
		{
			throw new NotImplementedException();
		}
	}

}
