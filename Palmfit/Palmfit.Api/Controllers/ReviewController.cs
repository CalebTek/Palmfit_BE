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
        private readonly IReviewRepository _reviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        private readonly IReviewRepository _reviewRepo; 
        private readonly UserManager<AppUser> _userManager;

        public ReviewController(IReviewRepository reviewRepo, UserManager<AppUser> userManager)
        {
            _reviewRepo = reviewRepo;
            _userManager = userManager;
        }



        [HttpDelete("delete-review")]
        public async Task<IActionResult> DeleteReview(string reviewId)
        {
            try
        {
            _reviewRepository = reviewRepository;
                var loggedInUser = HttpContext.User;
                var message = await _reviewRepo.DeleteReviewAsync(loggedInUser, reviewId);

                return Ok(ApiResponse.Success(message));
        }
        [HttpGet("get-review-by-user/{userId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ReviewDto>>> GetReviewsByUserId(string userId)
            catch (Exception ex)
        {
            var result = await _reviewRepository.GetReviewsByUserIdAsync(userId);
            return Ok(ApiResponse.Success(result));
                return BadRequest(ApiResponse.Failed(null, "An error occurred while deleting the review.", new List<string> { ex.Message }));
            }
        }








    }
}
