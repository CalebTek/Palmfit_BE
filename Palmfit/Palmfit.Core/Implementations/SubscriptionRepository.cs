using Newtonsoft.Json.Linq;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private readonly PalmfitDbContext _palmfitDbContext;
        public SubscriptionRepository(PalmfitDbContext palmfitDbContext)
        {
            _palmfitDb = palmfitDb;
            _palmfitDbContext = palmfitDbContext;
        }

        public async Task<Subscription> CreateSubscriptionAsync(CreateSubscriptionDto subscriptionDto, ClaimsPrincipal loggedInUser)
        public async Task<bool> DeleteSubscriptionAsync(string subscriptionId)
        {
            var subscription = new Subscription
            {
                Id = Guid.NewGuid().ToString(),
                Type = subscriptionDto.Type,
                StartDate = subscriptionDto.StartDate,
                EndDate = subscriptionDto.EndDate,
                AppUserId = loggedInUser.FindFirst(ClaimTypes.NameIdentifier).Value
            };
            var subscription =  await _palmfitDbContext.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriptionId);
            
            if (subscription == null)
                return await Task.FromResult(false);

            _palmfitDb.Subscriptions.Add(subscription);
            await _palmfitDb.SaveChangesAsync();
            _palmfitDbContext.Remove(subscription);
            await _palmfitDbContext.SaveChangesAsync();

            return subscription;
            return await Task.FromResult(true);
        }


    }

}
