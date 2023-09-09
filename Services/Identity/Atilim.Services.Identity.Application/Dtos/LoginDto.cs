using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atilim.Services.Identity.Application.Dtos
{
    public sealed class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
