using Biblio.Domain.Core.Models;
using Biblio.Domain.Core.Services.BiblioBookS;
using Biblio.Domain.Core.Services.BiblioFineS;
using Biblio.Domain.Core.Services.BiblioLendingInfoS;
using Biblio.Domain.Core.Services.BiblioReaderS;
using Biblio.Domain.Core.Services.ProfitReport;
using Biblio.Domain.Core.Services.UserS;
using Biblio.Infrastrusture.Data.Entities;
using Biblio.UtilityServices.Services.BiblioBook;
using Biblio.UtilityServices.Services.BiblioDiscount;
using Biblio.UtilityServices.Services.BiblioFine;
using Biblio.UtilityServices.Services.BiblioLending;
using Biblio.UtilityServices.Services.ProfitReport;
using Biblio.UtilityServices.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace Biblio.Domain.Core.Configs
{
    public static class DIConfig
    {
        public static void RegisterDomainInjections(this IServiceCollection services)
        {
            services.AddScoped<IBiblioBookBaseService<BiblioBookDomain>, BiblioBookDomainService>();
            services.AddScoped<IBiblioFineBaseService<BiblioFineDomain>, BiblioFineDomainService>();
            services.AddScoped<IBiblioReaderBaseService<BiblioReaderDomain>, BiblioReaderDomainService>();
            services.AddScoped<IBiblioLendingInfoBaseService<BiblioLendingInfoDomain>, BiblioLendingInfoDomainService>();
            services.AddScoped<IProfitReportBaseService, ProfitReportDomainService>();
            services.AddScoped<IUserBaseService<User>, UserDomainService>();
        }
    }
}
