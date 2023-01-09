using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Module4.Models
{
    public class UserContext: IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) 
        {

        }
    }
}
