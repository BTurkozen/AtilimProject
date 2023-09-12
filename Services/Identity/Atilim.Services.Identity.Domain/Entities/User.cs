using Atilim.Services.Identity.Domain.Entities.StudentEntities;
using Microsoft.AspNetCore.Identity;

namespace Atilim.Services.Identity.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public ICollection<UserRole> UserRoles { get; set; }

        //public string StudentIdentityId { get; set; }
        //public StudentIdentity StudentIdentity { get; set; }
    }
}
