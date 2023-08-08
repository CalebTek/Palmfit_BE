using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class MockSubscriptionRepository : ISubscriptionRepository
    {
        private readonly List<Subscription> _subscriptions;
        private readonly List<AppUser> _users;
        public MockSubscriptionRepository()
        {
            _users = new List<AppUser>
            {
                new AppUser { Id = "1", UserName = "user1" },
                new AppUser { Id = "2", UserName = "user2" }
            };

            _subscriptions = new List<Subscription>
            {
                new Subscription
                {
                    Id = "1",
                    Type = SubscriptionType.Basic,
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(30),
                    IsExpired = false,
                    AppUserId = "1",
                    AppUser = _users.FirstOrDefault(u => u.Id == "1")
                },
                new Subscription
                {
                    Id = "2",
                    Type = SubscriptionType.Standard,
                    StartDate = DateTime.Now.AddDays(-15),
                    EndDate = DateTime.Now.AddDays(45),
                    IsExpired = false,
                    AppUserId = "2",
                    AppUser = _users.FirstOrDefault(u => u.Id == "2")
                }
            };
        }

        public async Task<bool> DeleteSubscriptionAsync(string subscriptionId)
        {
            var subscription = _subscriptions.FirstOrDefault(s => s.Id == subscriptionId);

            if (subscription == null)
                return await Task.FromResult(false);

            _subscriptions.Remove(subscription);

            return await Task.FromResult(true);
        }
    }
}
