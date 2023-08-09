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

namespace Palmfit.Core.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly PalmfitDbContext _palmfitDb;
        private readonly UserManager<AppUser> _userManager;

        public ReviewRepository(PalmfitDbContext palmfitDb, UserManager<AppUser> userManager)  
        {
            _palmfitDb = palmfitDb;
            _userManager = userManager;
        }



        public async Task<Review> AddReviewAsync(AddReviewDto reviewDto)
        {
            var review = new Review
            {
                Id = Guid.NewGuid().ToString(),
                AppUserId = reviewDto.AppUserId,
                Date = DateTime.Now,
                Comment = reviewDto.Comment,
                Rating = reviewDto.Rating,
                Verdict = reviewDto.Verdict,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
               
            };

            _palmfitDb.Reviews.Add(review);
            await _palmfitDb.SaveChangesAsync();

            return review;
        }



        public async Task<string> DeleteReviewAsync(string userId, string reviewId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var review = await _palmfitDb.Reviews.FindAsync(reviewId);
            string message = "";
            if (user == null)
            {
                message= "User not found";
            } 
            else if(review.AppUserId != userId)
            {
                message = "You are not authorized to delete this review";
            }
            else if(review == null)
            {
                message = "Review not found";
            }
            else
            {
                review.IsDeleted = true;
                await _palmfitDb.SaveChangesAsync();
                message = "Review deleted successful";
            }
            return message;
        }



        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _palmfitDb.Reviews.ToListAsync();
        }




    }
}
