using Microsoft.AspNetCore.Identity;

namespace Atilim.Services.Identity.Domain.Entities
{
    public class UserRole : IdentityUserRole<string>
    {
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
