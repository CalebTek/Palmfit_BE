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



        public async Task<Subscription> GetUserSubscriptionStatusAsync(string userId)
        {
            return await _palmfitDb.Subscriptions.FirstOrDefaultAsync(sub => sub.AppUserId == userId);
        }



    }

}
