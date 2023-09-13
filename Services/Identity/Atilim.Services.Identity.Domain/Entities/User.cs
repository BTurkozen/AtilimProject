using Microsoft.AspNetCore.Identity;

namespace Atilim.Services.Identity.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
