using Atilim.Presentations.WebApplication.Services.Interfaces;

namespace Atilim.Presentations.WebApplication.Handlers
{
    public class JwtAuthenticationHandler : DelegatingHandler
    {
        private readonly IIdentityService _identityService;

        public JwtAuthenticationHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var jwtToken = await _identityService.GetJwtTokenAsync();

            if (!string.IsNullOrEmpty(jwtToken))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
