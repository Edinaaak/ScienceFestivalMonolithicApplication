namespace ScienceFestivalMonolithicApplication.DTOs.UserDTO
{
    public class UserAuthResponse
    {

        public string? Token { get; set; }

        public Models.User? User { get; set; }

        public string? Role { get; set; }

        public string? Error { get; set; }

        public int StatusCode { get; set; }
    }
}
