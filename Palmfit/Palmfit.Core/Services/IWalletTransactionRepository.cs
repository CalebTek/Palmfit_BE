using Palmfit.Data.Entities;
using Palmfit.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IWalletTransactionRepository
    {
        Task<PaginParameter<Transaction>> GetAllTransactionsAsync(int page, int pageSize);
    }
}
