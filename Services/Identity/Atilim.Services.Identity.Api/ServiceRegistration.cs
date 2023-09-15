using Atilim.Services.Identity.Api.Helpers.Extentions;
using Atilim.Services.Identity.Domain.Entities;
using Atilim.Services.Identity.Infrastructure;
using Atilim.Shared.Settings.Concrates;
using Atilim.Shared.Settings.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Atilim.Services.Identity.Api
{
    public static class ServiceRegistration
    {
        public static void AddWebApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 0;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

            }).AddEntityFrameworkStores<IdentityContext>()
.AddDefaultTokenProviders();

            var tokenConfiguration = configuration.GetSection(nameof(TokenSettings));

            services.Configure<TokenSettings>(tokenConfiguration);

            services.AddSingleton<ITokenSettings>(options =>
            {
                return options.GetRequiredService<IOptions<TokenSettings>>().Value;
            });

            services.AddCustomAuthentication(tokenConfiguration.Get<TokenSettings>());

            services.AddLogging(options =>
            {
                options.AddDebug();
                options.AddConsole();

            });
        }
    }
}
