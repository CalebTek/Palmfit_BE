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
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly PalmfitDbContext _dbContext;
        public ReviewsRepository(PalmfitDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Review>> GetReviewsByUserIdAsync(string userId)
        {
            var reviewsDto = new ReviewsDto();
            var reviews = new Review
            {
                Date = reviewsDto.Date,
                Comment = reviewsDto.Comment,
                Rating = reviewsDto.Rating,
                Verdict = reviewsDto.Verdict,
                AppUserId = reviewsDto.AppUserId
            };
            var ReviewResult = await _dbContext.Reviews.Where(r => r.AppUserId ==  userId).ToListAsync();
            if (!ReviewResult.Any())
            {
                return new List<Review>();
            }
            return ReviewResult;
            /*var ReviewResult = await _dbContext.Reviews.Where(r => r.AppUserId == userId).ToListAsync();
            if (!ReviewResult.Any())
            {
                return new List<ReviewsDto>();
            }
            return (ICollection<ReviewsDto>)ReviewResult;*/
        }
    }
    
}
