using Atilim.Shared.Settings.Concrates;
using Atilim.Shared.Settings.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Atilim.Presentations.WebApplication
{
    public static class ServiceRegistration
    {
        public static void AddWebApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfiguration = configuration.GetSection(nameof(TokenSettings));

            services.Configure<TokenSettings>(tokenConfiguration);

            services.AddSingleton<ITokenSettings>(options =>
            {
                return options.GetRequiredService<IOptions<TokenSettings>>().Value;
            });

            var tokenSettings = tokenConfiguration.Get<TokenSettings>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = tokenSettings.Issuer,
                    ValidAudience = tokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.SecurityKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            }).AddCookie(IdentityConstants.ApplicationScheme, options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.Events = new CookieAuthenticationEvents()
                {
                    OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync
                };
                options.ExpireTimeSpan = TimeSpan.FromDays(60);
                options.SlidingExpiration = true;
                options.Cookie.Name = "atilimprojectcookie";
            });
        }
    }
}