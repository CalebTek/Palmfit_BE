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
        public ReviewRepository(PalmfitDbContext palmfitDb)
        {
            _palmfitDb = palmfitDb;
        }


        public async Task<Review> CreateReviewAsync(CreateReviewDto reviewDto)
        {
            var review = new Review
            {
                Date = reviewDto.Date,
                Comment = reviewDto.Comment,
                Rating = reviewDto.Rating,
                Verdict = reviewDto.Verdict,
                AppUserId = reviewDto.AppUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _palmfitDb.Reviews.Add(review);
            await _palmfitDb.SaveChangesAsync();

            return review;
        }





        public async Task<bool> DeleteReviewAsync(string reviewId)
        {
            var review = await _palmfitDb.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return false;
            }

            review.IsDeleted = true;
            await _palmfitDb.SaveChangesAsync();

            return true;
        }


    }
}
