namespace ScienceFestivalMonolithicApplication.DTOs.ReviewDTO
{
    public class ReviewCreateRequest
    {
        public int ShowId { get; set; }
        public int JuryId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = default!;
    }
}
