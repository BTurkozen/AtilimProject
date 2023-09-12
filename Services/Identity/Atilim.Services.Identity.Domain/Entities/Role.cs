using Microsoft.AspNetCore.Identity;

namespace Atilim.Services.Identity.Domain.Entities
{
    public class Role : IdentityRole<string>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
