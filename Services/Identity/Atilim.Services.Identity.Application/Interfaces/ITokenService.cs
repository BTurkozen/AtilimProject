using Atilim.Services.Identity.Application.Dtos;
using Atilim.Services.Identity.Domain.Entities;
using Atilim.Shared.Dtos;

namespace Atilim.Services.Identity.Application.Interfaces
{
    public interface ITokenService
    {
        Task<ResponseDto<TokenDto>> CreateTokenAsync(User user);
    }
}
