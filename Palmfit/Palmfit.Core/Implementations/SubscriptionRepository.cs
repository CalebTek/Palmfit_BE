using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System.Security.Claims;

namespace Palmfit.Core.Implementations
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly PalmfitDbContext _db;

        public SubscriptionRepository(PalmfitDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteSubscriptionAsync(string subscriptionId)
        {
            var subscription = _db.Subscriptions.FirstOrDefault(s => s.Id == subscriptionId);

            if (subscription == null)
                return await Task.FromResult(false);

            _db.Remove(subscription);

            return await Task.FromResult(true);
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

            _db.Subscriptions.Add(subscription);
            await _db.SaveChangesAsync();

            return subscription;
        }

        public async Task<Subscription> GetUserSubscriptionStatusAsync(string userId)
        {
            {
                return await _db.Subscriptions.FirstOrDefaultAsync(sub => sub.AppUserId == userId);
            }

        }

    }
}