using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Subscription> CreateSubscriptionAsync(CreateSubscriptionDto subscriptionDto)
        {
            var subscription = new Subscription
            {
                Id = Guid.NewGuid().ToString(),
                Type = subscriptionDto.Type,
                StartDate = subscriptionDto.StartDate,
                EndDate = subscriptionDto.EndDate,
                AppUserId = subscriptionDto.AppUserId
            };

            _palmfitDb.Subscriptions.Add(subscription);
            await _palmfitDb.SaveChangesAsync();

            return subscription;
        }



        public async Task<Subscription> GetUserSubscriptionStatusAsync(string userId)
        {
            return await _palmfitDb.Subscriptions.Where(sub => sub.AppUserId == userId).OrderByDescending(sub => sub.StartDate).FirstOrDefaultAsync();
        }

    }

}
