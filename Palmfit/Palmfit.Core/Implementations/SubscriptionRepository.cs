using Microsoft.EntityFrameworkCore;
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
        private readonly PalmfitDbContext _dbContext;
        public SubscriptionRepository(PalmfitDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<Subscription> GetSubscriptionByIdAsync(string subscriptionId)
        {
            return await _dbContext.Subscriptions.FindAsync(subscriptionId);
        }

    }
}
