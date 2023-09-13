using Atilim.Services.Identity.Application.Dtos;
using Atilim.Services.Identity.Application.Interfaces;
using Atilim.Services.Identity.Domain.Entities;
using Atilim.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Atilim.Services.Identity.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IdentityContext _context;

        public AuthenticationService(UserManager<User> userManager, ITokenService tokenService, IdentityContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }

        public async Task<ResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto is null)
                throw new ArgumentNullException(nameof(loginDto));

            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user is null)
                return ResponseDto<TokenDto>.Fail("Username or Password is wrong", HttpStatusCode.BadRequest);

            if (await _userManager.CheckPasswordAsync(user, loginDto.Password) is false)
                return ResponseDto<TokenDto>.Fail("Username or Password is wrong", HttpStatusCode.BadRequest);

            var tokenResponse = await _tokenService.CreateTokenAsync(user);

            var userRefreshToken = await _context.UserRefreshTokens.FirstOrDefaultAsync(t => t.UserId == user.Id);

            if (userRefreshToken is null)
            {
                await _context.UserRefreshTokens.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    Code = tokenResponse.Data.RefreshToken,
                    Expiration = tokenResponse.Data.RefreshTokenExpiration
                });
            }
            else
            {
                userRefreshToken.Code = tokenResponse.Data.RefreshToken;
                userRefreshToken.Expiration = tokenResponse.Data.RefreshTokenExpiration;
            }

            await _context.SaveChangesAsync();

            return ResponseDto<TokenDto>.Success(tokenResponse.Data, HttpStatusCode.OK);
        }

        public async Task<ResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _context.UserRefreshTokens.FirstOrDefaultAsync(rt => rt.Code == refreshToken);
            if (existRefreshToken is null)
                return ResponseDto<TokenDto>.Fail("Refresh token not found", HttpStatusCode.NotFound);

            var user = await _userManager.FindByIdAsync($"{existRefreshToken.UserId}");

            if (user is null)
                return ResponseDto<TokenDto>.Fail("Username or Password is wrong", HttpStatusCode.BadRequest);

            var tokenResponse = await _tokenService.CreateTokenAsync(user);

            existRefreshToken.Code = tokenResponse.Data.RefreshToken;
            existRefreshToken.Expiration = tokenResponse.Data.RefreshTokenExpiration;

            await _context.SaveChangesAsync();

            return ResponseDto<TokenDto>.Success(tokenResponse.Data, HttpStatusCode.OK);
        }
        public async Task<ResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _context.UserRefreshTokens.FirstOrDefaultAsync(rt => rt.Code == refreshToken);

            if (existRefreshToken is null)
                return ResponseDto<NoContentDto>.Fail("Refresh token not found", HttpStatusCode.NotFound);

            _context.Remove(existRefreshToken);

            await _context.SaveChangesAsync();

            return ResponseDto<NoContentDto>.Success(HttpStatusCode.OK);
        }
    }
}
