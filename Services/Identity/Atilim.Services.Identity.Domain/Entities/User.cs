using Microsoft.AspNetCore.Identity;

namespace Atilim.Services.Identity.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            UserRoles = new List<UserRole>();
            Id = Guid.NewGuid().ToString();
        }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
