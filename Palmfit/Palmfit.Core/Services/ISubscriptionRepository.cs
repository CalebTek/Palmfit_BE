using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface ISubscriptionRepository
    {
        Task<Subscription> GetSubscriptionByIdAsync(string subscriptionId);
        Task<IEnumerable<Subscription>> GetSubscriptionsByUserIdAsync(string userId);
        Task<IEnumerable<Subscription>> GetSubscriptionsByUserNameAsync(string userName);
    }
}
