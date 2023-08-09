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

namespace Palmfit.Core.Implementations
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly PalmfitDbContext _palmfitcontext;
		private readonly UserManager<AppUser> _userManager;

		public ReviewRepository(PalmfitDbContext palmfitcontext, UserManager<AppUser> userManager)
		{
			_palmfitcontext = palmfitcontext;
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

				_palmfitcontext.Reviews.Add(review);
				_palmfitcontext.SaveChanges();

				return "Review Updated Sucessfully!";
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(ex.Message);
			}
			
		}

	}
}
