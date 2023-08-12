using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using System.Data;
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
        public async Task<IActionResult> DeleteReview(string reviewId)
        {
            try
            {
                var loggedInUser = HttpContext.User;
                var message = await _reviewRepo.DeleteReviewAsync(loggedInUser, reviewId);

                return Ok(ApiResponse.Success(message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(null, "An error occurred while deleting the review.", new List<string> { ex.Message }));
            }
        }


        [HttpGet("get-review-by-user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ReviewDto>>> GetReviewsByUserId(string userId)
        {
                var result = await _reviewRepo.GetReviewsByUserIdAsync(userId);
                return Ok(ApiResponse.Success(result));
        }







    }
}

