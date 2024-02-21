using NomadChat.WebAPI.Configs;
using Biblio.Domain.Core.Configs;
using Biblio.Infrastructure.Business.Configs;
using Biblio.Infrastrusture.Data.Configs;

namespace NomadChat.WebAPI.Helpers.IoC
{
    public static class DIInitializer
    {
        public static void RegisterAllinjections(this IServiceCollection services)
        {
            services.RegisterWebAPIInjections();
            services.RegisterDomainInjections();
            services.RegisterInfrastructureBusinessInjections();
            services.RegisterInfrastructureDataInjections();
        }
    }
}
