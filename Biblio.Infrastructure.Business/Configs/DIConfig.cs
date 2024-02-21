using Biblio.Infrastructure.Business.Services.Auth;
using Biblio.Infrastructure.Business.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace Biblio.Infrastructure.Business.Configs
{
    public static class DIConfig
    {
        public static void RegisterInfrastructureBusinessInjections(this IServiceCollection services)
        {
            services.AddScoped<IAuthInfrastructureService, AuthInfrastructureService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
