namespace ScienceFestivalMonolithicApplication.DTOs.MessageDTO
{
    public class MessageCreateRequest
    {
        public string Comment { get; set; } = default!;
        public int ShowId { get; set; }
        public int JuryId { get; set; }

        public int Rating { get; set; }
    }
}
