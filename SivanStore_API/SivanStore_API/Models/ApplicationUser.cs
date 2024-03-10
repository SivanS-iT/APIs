using Microsoft.AspNetCore.Identity;

namespace SivanStore_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name{ get; set; }
    }
}
