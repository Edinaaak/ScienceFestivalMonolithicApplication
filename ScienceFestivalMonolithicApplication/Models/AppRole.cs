using Microsoft.AspNetCore.Identity;

namespace ScienceFestivalMonolithicApplication.Models
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole(string roleName): base(roleName) { }

        public AppRole() { }

    }
}
