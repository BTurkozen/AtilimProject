using Microsoft.AspNetCore.Identity;

namespace Atilim.Services.Identity.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
