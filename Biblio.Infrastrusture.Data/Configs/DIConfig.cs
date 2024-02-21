using Biblio.Infrastrusture.Data.Repositories;
using Biblio.Infrastrusture.Data.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace Biblio.Infrastrusture.Data.Configs
{
    public static class DIConfig
    {
        public static void RegisterInfrastructureDataInjections(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBiblioBookRepository, BiblioBookRepository>();
            services.AddScoped<IBiblioLendingInfoRepository, BiblioLendingInfoRepository>();
            services.AddScoped<IBiblioFineRepository, BiblioFineRepository>();
            services.AddScoped<IBiblioReaderRepository, BiblioReaderRepository>();
        }
    }
}
