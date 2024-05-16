using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScienceFestivalMonolithicApplication.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Show))]
        public int ShowId { get; set; }
        public Show Show { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User Jury { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
