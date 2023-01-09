using Microsoft.AspNetCore.Identity;

namespace Module4.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
