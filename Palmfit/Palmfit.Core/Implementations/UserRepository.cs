using Microsoft.AspNetCore.Identity;
using Palmfit.Core.Interfaces;
using Palmfit.Data.Common.Dtos;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Palmfit.Core.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CreateUser(SignUpDto userRequest)
        {
            var user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user != null) return false;

            user = new AppUser()
            {
                FirstName = userRequest.Firstname,
                LastName = userRequest.Lastname,
                Email = userRequest.Email,
                


            };

            TransactionManager.ImplicitDistributedTransactions = true;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createUser = await _userManager.CreateAsync(user, userRequest.Password);
                if (createUser.Succeeded)
                {
                    transaction.Complete();
                    return true;
                }
            }

            return false;
        }
    }
}
