using Microsoft.AspNetCore.Identity;
﻿using Microsoft.EntityFrameworkCore;
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
		private readonly PalmfitDbContext _dbContext;
		private readonly UserManager<AppUser> _userManager;

		public ReviewRepository(PalmfitDbContext palmfitcontext, UserManager<AppUser> userManager)
		{
			_dbContext = palmfitcontext;
			_userManager = userManager;
		}

		public async Task<string> AddReview(ReviewDTO reviewDTO, string userId)
		{
			try
			{
				var validateUser = await _userManager.FindByIdAsync(userId);

				if (validateUser == null)
				{
					return null;
				}

				Review review = new Review()
				{
					Date = DateTime.Now.Date,
					Comment = reviewDTO.Comment,
					Rating = reviewDTO.Rating,
					Verdict = reviewDTO.Verdict,
					AppUserId = userId,
					Id = Guid.NewGuid().ToString(),
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					IsDeleted = false
				};

				_dbContext.Reviews.Add(review);
				_dbContext.SaveChanges();

				return "Review Updated Sucessfully!";
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
			
		}

	}


        public async Task<List<Review>> GetReviewsByUserIdAsync(string userId)
        {
            var reviewsDto = new ReviewDto();
            var reviews = new Review
            {
                Date = reviewsDto.Date,
                Comment = reviewsDto.Comment,
                Rating = reviewsDto.Rating,
                Verdict = reviewsDto.Verdict,
                AppUserId = reviewsDto.AppUserId
            };
            var ReviewResult = await _dbContext.Reviews.Where(r => r.AppUserId == userId).ToListAsync();
            if (!ReviewResult.Any())
            {
                return new List<Review>();
            }
            return ReviewResult;

    }

}
