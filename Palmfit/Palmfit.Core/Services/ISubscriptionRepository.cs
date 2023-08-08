using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface ISubscriptionRepository
    {
        Task<bool> DeleteSubscriptionAsync(string subscriptionId);
    }
}
