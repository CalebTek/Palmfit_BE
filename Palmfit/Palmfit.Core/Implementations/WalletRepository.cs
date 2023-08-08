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
    public class WalletRepository :IWalletRepository
    {

        private readonly PalmfitDbContext _db;

        public WalletRepository(PalmfitDbContext db)
        {
            _db = db;
        }

        public async Task<Wallet> GetWalletByUserId(string userId)
        {
            return await _db.Wallets.FirstOrDefaultAsync(w => w.AppUserId == userId);
        }
        public async Task<string> RemoveFundFromWallet(string walletId, decimal amount)
        {
            var wallet = await _db.Wallets.FirstOrDefaultAsync(w => w.Id == walletId);

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

        Task<List<Wallet>> IWalletRepository.GetWalletByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
