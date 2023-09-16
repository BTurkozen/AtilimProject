using Atilim.Shared.Settings.Concrates;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Atilim.Presentations.WebApplication.Extententions
{
    public static class CookieAuthenticationService
    {
        public static void AddCookieAuthenticationService(this IServiceCollection services, TokenSettings tokenSettings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
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
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Home/Index");
                options.ExpireTimeSpan = TimeSpan.FromDays(tokenSettings.AccessTokenExpiration);
                options.SlidingExpiration = true;
                options.Cookie.Name = "atilimprojectcookie";
            });
        }
    }
}
