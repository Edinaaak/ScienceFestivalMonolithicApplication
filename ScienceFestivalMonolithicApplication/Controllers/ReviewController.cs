using Microsoft.AspNetCore.Mvc;
using ScienceFestivalMonolithicApplication.DTOs.ReviewDTO;
using ScienceFestivalMonolithicApplication.Interfaces;
using ScienceFestivalMonolithicApplication.Services;

namespace ScienceFestivalMonolithicApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("add-review")]
        public async Task<IActionResult> AddReview(ReviewCreateRequest reviewDTO)
        {
            try
            {
                var review = await _reviewService.AddReview(reviewDTO);
                return Ok(review);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-reviews")]
        public async Task<IActionResult> GetReviews()
        {
            try
            {
                var reviews = await _reviewService.GetAllReviews();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-reviews-for-jury/{id}")]
        public async Task<IActionResult> GetReviewsForJury(int id)
        {
            try
            {
                var reviews = await _reviewService.GetReviewsForJury(id);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-reviews-for-show/{showId}")]
        public async Task<IActionResult> GetReviewsForShow(int showId)
        {
            try
            {
                var reviews = await _reviewService.GetReviewsForShow(showId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
