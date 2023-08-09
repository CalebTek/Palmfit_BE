using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using Palmfit.Data.EntityEnums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly PalmfitDbContext _palmfitDbContext;
        public SubscriptionRepository(PalmfitDbContext palmfitDbContext)
        {
            _palmfitDbContext = palmfitDbContext;
        }  

        public async Task<bool> DeleteSubscriptionAsync(string subscriptionId)
        {
            var subscription =  await _palmfitDbContext.Subscriptions.FirstOrDefaultAsync(s => s.Id == subscriptionId);
            
            if (subscription == null)
                return await Task.FromResult(false);

            _palmfitDbContext.Remove(subscription);
            await _palmfitDbContext.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
