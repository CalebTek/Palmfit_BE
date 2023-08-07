using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palmfit.Data.Entities;

namespace Palmfit.Core.Services
{
    public interface IWalletRepository
    {
        Task<Wallet> GetWalletByUserIdAsync(string appUserId);
    }
}
