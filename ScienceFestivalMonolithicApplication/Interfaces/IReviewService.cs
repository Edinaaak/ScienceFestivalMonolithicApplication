using ScienceFestivalMonolithicApplication.DTOs.ReviewDTO;
using ScienceFestivalMonolithicApplication.Models;

namespace ScienceFestivalMonolithicApplication.Interfaces
{
    public interface IReviewService
    {

        public Task<Review> AddReview(ReviewCreateRequest review);
        public Task<List<Review>> GetAllReviews();

        public Task<List<Review>> GetReviewsForJury(int juryId);

        public Task<List<Review>> GetReviewsForShow(int showId);
    }
}
