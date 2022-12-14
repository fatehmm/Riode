using Microsoft.AspNetCore.Identity;

namespace Riode.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
