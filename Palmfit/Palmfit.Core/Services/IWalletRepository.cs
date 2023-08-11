﻿using Core.Helpers;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Services
{
    public interface IWalletRepository
    {
        Task<Wallet> GetWalletByUserId(string userId);
        Task<string> RemoveFundFromWallet(string walletId, decimal amount);
        Task<PaginParameter<WalletHistory>> WalletHistories(int page, int pageSize);
    }
}