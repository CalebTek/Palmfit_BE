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
    }
}
