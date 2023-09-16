using Atilim.Presentations.WebApplication.Handlers;
using Atilim.Presentations.WebApplication.Services.Concrates;
using Atilim.Presentations.WebApplication.Services.Interfaces;

namespace Atilim.Presentations.WebApplication.Extententions
{
    public static class HttpClientIntegrationService
    {
        public static void AddCustomHttpClientIntegration(this IServiceCollection services)
        {
            services.AddHttpClient<IIdentityService, IdentityService>();

            services.AddTransient<JwtAuthenticationHandler>();

            services.AddHttpClient<ICurriculumService, CurriculumService>().AddHttpMessageHandler<JwtAuthenticationHandler>();

            services.AddHttpClient<ILessonService, LessonService>().AddHttpMessageHandler<JwtAuthenticationHandler>();
        }
    }
}
