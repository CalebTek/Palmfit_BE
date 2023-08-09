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
        private readonly PalmfitDbContext _dbContext;
        public SubscriptionRepository(PalmfitDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Subscription> GetSubscriptionByIdAsync(string subscriptionId)
        {
            return await Task.FromResult(_dbContext.Subscriptions.FirstOrDefault(s => s.Id == subscriptionId));
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByUserIdAsync(string userId)
        {
            return await _dbContext.Subscriptions.Where(s => s.AppUserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsByUserNameAsync(string userName)
        {
            return await _dbContext.Subscriptions.Where(s => s.AppUser.UserName == userName).ToListAsync();
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

            _dbContext.Subscriptions.Add(subscription);
            await _dbContext.SaveChangesAsync();

            return subscription;
        }
    }
}

