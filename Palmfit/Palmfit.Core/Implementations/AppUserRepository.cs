using Microsoft.AspNetCore.Identity;
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
using System.Transactions;

namespace Palmfit.Core.Implementations
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly PalmfitDbContext _dbContext;

        public AppUserRepository(UserManager<AppUser> userManager, PalmfitDbContext dbContext)
        public AppUserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        {
            var user = await _userManager.FindByEmailAsync(userRequest.Email);
            user = new AppUser()
            {
                FirstName = userRequest.Firstname,
                LastName = userRequest.Lastname,
                Email = userRequest.Email,
                UserName = userRequest.Email
                    


            };

                TransactionManager.ImplicitDistributedTransactions = true;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createUser = await _userManager.CreateAsync(user, userRequest.Password);
                transaction.Complete();
            }
        }

        }
    }
}

