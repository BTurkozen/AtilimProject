using Atilim.Services.Identity.Application.Dtos;
using Atilim.Services.Identity.Application.Interfaces;
using Atilim.Services.Identity.Domain.Entities;
using Atilim.Shared.Dtos;
using Atilim.Shared.Settings.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Atilim.Services.Identity.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenSettings _tokenSettings;

        public TokenService(UserManager<User> userManager, ITokenSettings tokenSettings)
        {
            _userManager = userManager;
            _tokenSettings = tokenSettings;
        }

        private async Task<IEnumerable<Claim>> GetClaims(User user, string audience)
        {
            var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Aud, audience),
        };

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            return claims;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new byte[32];

            using var randomGen = RandomNumberGenerator.Create();

            randomGen.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

        public async Task<ResponseDto<TokenDto>> CreateTokenAsync(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenSettings.AccessTokenExpiration);

            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenSettings.RefreshTokenExpiration);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecurityKey));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenSettings.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: await GetClaims(user, _tokenSettings.Audience),
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler jwtHandler = new();

            var token = jwtHandler.WriteToken(jwtSecurityToken);

            TokenDto tokenDto = new()
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };

            return ResponseDto<TokenDto>.Success(tokenDto, System.Net.HttpStatusCode.OK);
        }
    }
}
