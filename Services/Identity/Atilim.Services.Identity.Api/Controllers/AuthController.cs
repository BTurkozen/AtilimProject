using Atilim.Services.Identity.Application.Dtos;
using Atilim.Services.Identity.Application.Interfaces;
using Atilim.Shared.CustomControllerBases;
using Atilim.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Services.Identity.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            return CustomActionResult(await _authenticationService.CreateTokenAsync(loginDto));
        }
    }
}
