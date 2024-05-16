using Microsoft.AspNetCore.Identity;
using System.Data;

namespace ScienceFestivalMonolithicApplication.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
    }
}
