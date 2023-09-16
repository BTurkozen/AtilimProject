using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Presentations.WebApplication.ViewModels;
using Atilim.Shared.Dtos;
using Atilim.Shared.Settings.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Atilim.Presentations.WebApplication.Services.Concrates
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IClientInfos _clientInfos;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor contextAccessor, IClientInfos clientInfos)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _clientInfos = clientInfos;
        }

        public async Task<string> GetJwtTokenAsync()
        {
            var jwtToken = _contextAccessor.HttpContext.Request.Cookies["access_token"];

            if (jwtToken == null)
            {
                return string.Empty;
            }

            return jwtToken.ToString();
        }

        public async Task<bool> SigninAsync(LoginViewModel loginViewModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var response = await _httpClient.PostAsJsonAsync<LoginViewModel>($"{_clientInfos.URL}/auth/CreateToken", loginViewModel);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseToken = await response.Content.ReadFromJsonAsync<ResponseDto<TokenDto>>();

                var token = tokenHandler.ReadJwtToken(responseToken.Data.AccessToken);

                var tokenString = tokenHandler.WriteToken(token);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddMinutes(5)
                };

                _contextAccessor.HttpContext.Response.Cookies.Append("access_token", responseToken.Data.AccessToken, cookieOptions);

                var claims = token.Claims.ToList();

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var properties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5),
                    IsPersistent = false,
                    AllowRefresh = true
                };

                await _contextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal, properties);

                return true;
            }

            return false;
        }
    }
}
