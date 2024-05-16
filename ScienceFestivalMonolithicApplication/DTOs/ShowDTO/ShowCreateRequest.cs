namespace ScienceFestivalMonolithicApplication.DTOs.ShowDTO
{
    public class ShowCreateRequest
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        
        public int UserId { get; set; }
       
    }
}
