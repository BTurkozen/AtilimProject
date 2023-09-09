using Atilim.Services.Identity.Application.Dtos;
using Atilim.Shared.Dtos;

namespace Atilim.Services.Identity.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<ResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<ResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken);
    }
}
