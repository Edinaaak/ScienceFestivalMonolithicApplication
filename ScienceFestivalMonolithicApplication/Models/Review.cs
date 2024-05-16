using System.ComponentModel.DataAnnotations.Schema;

namespace ScienceFestivalMonolithicApplication.Models
{
    public class Review
    {
        public int Id { get; set; }

        [ForeignKey("Show")]
        public int ShowId { get; set; }
        public Show Show { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
