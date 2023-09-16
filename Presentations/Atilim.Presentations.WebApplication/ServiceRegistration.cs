using Atilim.Presentations.WebApplication.Extententions;
using Atilim.Presentations.WebApplication.Services.Concrates;
using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Shared.Settings.Concrates;
using Atilim.Shared.Settings.Interfaces;
using Microsoft.Extensions.Options;

namespace Atilim.Presentations.WebApplication
{
    public static class ServiceRegistration
    {
        public static void AddWebApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddHttpClient<IIdentityService, IdentityService>();

            var clientInfosConfiguration = configuration.GetSection(nameof(ClientInfos));

            services.Configure<ClientInfos>(clientInfosConfiguration);

            services.AddSingleton<IClientInfos>(options =>
            {
                return options.GetRequiredService<IOptions<ClientInfos>>().Value;
            });

            var tokenConfiguration = configuration.GetSection(nameof(TokenSettings));

            services.Configure<TokenSettings>(tokenConfiguration);

            services.AddSingleton<ITokenSettings>(options =>
            {
                return options.GetRequiredService<IOptions<TokenSettings>>().Value;
            });

            // Authentication => JWT ve Cookie service register.
            services.AddCookieAuthenticationService(tokenConfiguration.Get<TokenSettings>());
        }
    }
}