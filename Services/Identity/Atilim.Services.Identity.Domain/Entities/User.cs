﻿using Microsoft.AspNetCore.Identity;

namespace Atilim.Services.Identity.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
