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
    public class WalletRepository : IWalletRepository
    {
        private readonly PalmfitDbContext _context;

        public WalletRepository(PalmfitDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet> GetWalletByUserIdAsync(string appUserId)
        {
            return await _context.Wallets.FirstOrDefaultAsync(w => w.AppUserId == appUserId);

            //return await _context.Wallets.Include(w => w.Transaction).FirstOrDefaultAsync(w => w.AppUserId == appUserId);
        }
    }
}
