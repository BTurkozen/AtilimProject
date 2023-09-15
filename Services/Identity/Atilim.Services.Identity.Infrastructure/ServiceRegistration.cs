using Atilim.Services.Identity.Application.Interfaces;
using Atilim.Services.Identity.Application.Interfaces.StudentInterfaces;
using Atilim.Services.Identity.Infrastructure.Services;
using Atilim.Services.Identity.Infrastructure.Services.StudentServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atilim.Services.Identity.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStr"));
                options.EnableSensitiveDataLogging(true);
            });

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<ITokenService, TokenService>();

            #region Students Register
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<IStudentIdentityService, StudentIdentityService>();

            services.AddScoped<IContactInformationService, ContactInformationService>();

            services.AddScoped<ICurriculumService, CurriculumService>();

            services.AddScoped<ILessonService, LessonService>();
            #endregion

        }
    }
}
