using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;

namespace Palmfit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepo; 
        private readonly UserManager<AppUser> _userManager;

        public ReviewController(IReviewRepository reviewRepo, UserManager<AppUser> userManager)
        {
            _reviewRepo = reviewRepo;
            _userManager = userManager;
        }


        [HttpPost("add-review")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewDto reviewDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse.Failed("Invalid review data."));
                }

                // Ensuring the user exists
                var user = await _userManager.FindByIdAsync(reviewDto.AppUserId);
                if (user == null)
                {
                    return NotFound(ApiResponse.Failed("User not found."));
                }

                var createdReview = await _reviewRepo.AddReviewAsync(reviewDto);
                if (createdReview != null)
                {
                    return Ok(ApiResponse.Success("Review added successfully."));
                }
                else
                {
                    return BadRequest(ApiResponse.Failed("Failed to add review."));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed("An error occurred while adding the review.", errors: new List<string> { ex.Message }));
            }
        }



        [HttpDelete("delete-review")]
        public async Task<IActionResult> DeleteReview(string userId, string reviewId)
        {
            try
            {
                var message = await _reviewRepo.DeleteReviewAsync(userId, reviewId);

                return Ok(ApiResponse.Success(message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(null, "An error occurred while deleting the review.", new List<string> { ex.Message }));
            }
        }




        [HttpGet("get-all-reviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                var reviews = await _reviewRepo.GetAllReviewsAsync();
                if (reviews == null)
                {
                    return NotFound(ApiResponse.Failed("Review not found."));
                }
                return Ok(ApiResponse.Success(reviews));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(null, "An error occurred while fetching reviews.", errors: new List<string> { ex.Message }));
            }
        }







    }
}
