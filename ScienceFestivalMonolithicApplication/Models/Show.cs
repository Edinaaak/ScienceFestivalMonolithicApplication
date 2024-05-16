using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScienceFestivalMonolithicApplication.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User Performer { get; set; }
        public bool Accepted { get; set; }
        public string ReleaseDate { get; set; }
    }
}
