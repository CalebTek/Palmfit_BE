using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
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
    public class ReviewRepository : IReviewRepository
    {
        private readonly PalmfitDbContext _palmfitDbContext;
        private readonly UserManager<AppUser> _userManager;

        public ReviewRepository(PalmfitDbContext palmfitDbContext, UserManager<AppUser> userManager)  
        {
            _palmfitDbContext = palmfitDbContext;
            _userManager = userManager;
        }


        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _palmfitDbContext.Reviews.Where(review => review.IsDeleted == false).ToListAsync();
        }
         

    }
}
