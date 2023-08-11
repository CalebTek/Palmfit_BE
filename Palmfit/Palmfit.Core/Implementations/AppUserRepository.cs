//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
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
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<string> CreateUser(SignUpDto userRequest)
        {
            var user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user == null)
            {

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
                    if (ApiResponse.Success(createUser) != null)
                    {

                        transaction.Complete();
                        return "User added successfully";
                    }
                }
            }

            return "There was a problem registring user";
        }
        public async Task<AppUser> GetUserById(string userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }
    }
}

