using System.ComponentModel.DataAnnotations;

namespace ScienceFestivalMonolithicApplication.DTOs.UserDTO
{
    public class UserLoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
