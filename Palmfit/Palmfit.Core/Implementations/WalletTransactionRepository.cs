using Core.Helpers;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class WalletTransactionRepository : IWalletTransactionRepository
    {
        private readonly PalmfitDbContext _palmfitDb;
        public WalletTransactionRepository(PalmfitDbContext palmfitDb)
        {
            _palmfitDb = palmfitDb;
        }

        public async Task<PaginParameter<Transaction>> GetAllTransactionsAsync(int page, int pageSize)
        {
            var totalCount = await _palmfitDb.Transactions.CountAsync();

            var transactions = await _palmfitDb.Transactions.OrderByDescending(x => x.CreatedAt).ToListAsync();

            transactions = await _palmfitDb.Transactions
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();

            return new PaginParameter<Transaction>
            {
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                Data = transactions
            };
        }
    }
}
