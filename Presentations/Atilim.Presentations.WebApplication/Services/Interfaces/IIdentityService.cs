using Atilim.Presentations.WebApplication.ViewModels;

namespace Atilim.Presentations.WebApplication.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetJwtTokenAsync();

        Task<bool> SigninAsync(LoginViewModel loginViewModel);
    }
}
