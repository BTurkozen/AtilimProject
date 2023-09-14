using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Atilim.Services.Identity.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(assembly);
        }
    }
}
