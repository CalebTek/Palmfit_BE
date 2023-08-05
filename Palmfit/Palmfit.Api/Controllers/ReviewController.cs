using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Palmfit.Core.Dtos;
using Palmfit.Core.Services;
using Palmfit.Data.Entities;
using System.Security.Claims;

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




        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse.Failed(null, "Invalid review data."));
            }

            // Get the user ID from claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Check if the user is logged in and exists
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Unauthorized(ApiResponse.Failed(null, "User not logged in or does not exist."));
            }

            try
            {
                var createdReview = await _reviewRepo.CreateReviewAsync(reviewDto);
                return Ok(ApiResponse.Success("Review created successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(null, "Failed to create review.", new List<string> { ex.Message }));
            }
        }








        [HttpDelete("delete/{reviewId}")]
        public async Task<IActionResult> DeleteReview(string reviewId)
        {
            try
            {
                var isDeleted = await _reviewRepo.DeleteReviewAsync(reviewId);
                if (isDeleted)
                {
                    return Ok(ApiResponse.Success("Review deleted successfully."));
                }
                else
                {
                    return NotFound(ApiResponse.Failed(null, "Review not found."));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse.Failed(null,"Failed to delete review.", new List<string> { ex.Message }));
            }
        }







    }
}
