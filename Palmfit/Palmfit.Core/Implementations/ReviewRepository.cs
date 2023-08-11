using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.AppDbContext;
using Palmfit.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Palmfit.Core.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly PalmfitDbContext _dbContext;
        public ReviewRepository(PalmfitDbContext dbContext)
        private readonly PalmfitDbContext _palmfitDb;
        private readonly UserManager<AppUser> _userManager;

        public ReviewRepository(PalmfitDbContext palmfitDb, UserManager<AppUser> userManager)  
        {
            _dbContext = dbContext;
            _palmfitDb = palmfitDb;
            _userManager = userManager;
        }

        public async Task<List<Review>> GetReviewsByUserIdAsync(string userId)

        public async Task<string> DeleteReviewAsync(ClaimsPrincipal loggedInUser, string reviewId)
        {
            var reviewsDto = new ReviewDto();
            var reviews = new Review
            var user = loggedInUser.FindFirst(ClaimTypes.NameIdentifier);       
            var review = await _palmfitDb.Reviews.FindAsync(reviewId);

            string message = "";
            if (user == null)
            {
                message= "User not found";
            } 
            else if(review.AppUserId != user.Value)
            {
                message = "You are not authorized to delete this review";
            }
            else if(review == null)
            {
                Date = reviewsDto.Date,
                Comment = reviewsDto.Comment,
                Rating = reviewsDto.Rating,
                Verdict = reviewsDto.Verdict,
                AppUserId = reviewsDto.AppUserId
            };
            var ReviewResult = await _dbContext.Reviews.Where(r => r.AppUserId == userId).ToListAsync();
            if (!ReviewResult.Any())
                message = "Review not found";
            }
            else
            {
                return new List<Review>();
                review.IsDeleted = true;
                await _palmfitDb.SaveChangesAsync();
                message = "Review deleted successful";
            }
            return message;
            }
            return ReviewResult;



        }
    }
}
