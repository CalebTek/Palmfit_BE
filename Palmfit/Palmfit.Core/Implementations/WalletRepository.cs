using Core.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
    public class WalletRepository : IWalletRepository
    {

        private readonly PalmfitDbContext _palmfitDb;

        public WalletRepository(PalmfitDbContext palmfitDb)
        {
            _palmfitDb = palmfitDb;
        }

        public async Task<Wallet> GetWalletByUserId(string userId)
        {
            return await _palmfitDb.Wallets.FirstOrDefaultAsync(w => w.AppUserId == userId);
        }

        public async Task<string> RemoveFundFromWallet(string walletId, decimal amount)
        {
            var wallet = await _palmfitDb.Wallets.FirstOrDefaultAsync(w => w.Id == walletId);

            if (wallet == null)
            {
                return "Wallet not found"; // Wallet not found
            }

            if (wallet.Balance < amount)
            {
                return "Insufficient Balance, Please fund your wallet"; // Insufficient funds
            }

            wallet.Balance -= amount;
            return "Successfully removed fund"; // Successfully removed funds
        }

        public async Task<PaginParameter<WalletHistory>> WalletHistories(int page, int pageSize)
        {

            int totalCount = await _palmfitDb.WalletHistories.CountAsync();
            int skip = (page - 1) * pageSize;

            var histories = await _palmfitDb.WalletHistories
                .Include(i => i.Wallet)
                .OrderByDescending(t => t.Date)
                .Skip(skip)
                .ToListAsync();

            var paginatedResponse = new PaginParameter<WalletHistory>
            {
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                Data = histories
            };

            return paginatedResponse;
        }
    }
}
