﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpPut("Update-review/{userId}")]
        public async Task<IActionResult> UpdateReview(string userId, [FromBody] ReviewDto reviewDto)
        {
            var result = await _reviewRepo.UpdateReviewAsync(userId, reviewDto);
            if (!result.Any()) return BadRequest(ApiResponse.Failed("Failed to update"));


            return Ok(ApiResponse.Success(result));

        }



        [HttpGet("get-all-reviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                var reviews = await _reviewRepo.GetAllReviewsAsync();
                if (!reviews.Any())
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
