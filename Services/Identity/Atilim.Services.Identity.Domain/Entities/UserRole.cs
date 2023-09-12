using Microsoft.AspNetCore.Identity;

namespace Atilim.Services.Identity.Domain.Entities
{
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; }

        //public Role Role { get; set; }
    }
}
