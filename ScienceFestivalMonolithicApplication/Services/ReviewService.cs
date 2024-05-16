using Microsoft.EntityFrameworkCore;
using ScienceFestivalMonolithicApplication.DTOs.ReviewDTO;
using ScienceFestivalMonolithicApplication.Interfaces;
using ScienceFestivalMonolithicApplication.Models;
using ScienceFestivalMonolithicApplication.Persistance;

namespace ScienceFestivalMonolithicApplication.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DatabaseContext context;

        public ReviewService(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public async Task<Review> AddReview(ReviewCreateRequest reviewDTO)
        {

            var review = new Review
            {
                ShowId = reviewDTO.ShowId,
                UserId = reviewDTO.JuryId,
                Rating = reviewDTO.Rating,
                Comment = reviewDTO.Comment
            };

            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
            return review;

        }

        public async Task<List<Review>> GetAllReviews()
        {
            return await context.Reviews.ToListAsync();
        }

        public async Task<List<Review>> GetReviewsForJury(int juryId)
        {
            return await context.Reviews.Where(r => r.UserId == juryId).ToListAsync();
        }

        public Task<List<Review>> GetReviewsForShow(int showId)
        {
            return context.Reviews.Where(r => r.ShowId == showId).ToListAsync();
        }
    }
}
