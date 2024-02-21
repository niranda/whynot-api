using Biblio.Domain.Core.Models;
using Biblio.Domain.Core.Services.ProfitReport;
using Biblio.UtilityServices.Services.Auth;
using Biblio.UtilityServices.Services.BiblioBook;
using Biblio.UtilityServices.Services.BiblioDiscount;
using Biblio.UtilityServices.Services.BiblioFine;
using Biblio.UtilityServices.Services.BiblioLending;
using Biblio.UtilityServices.Services.ProfitReport;
using NomadChat.WebAPI.Services;

namespace NomadChat.WebAPI.Configs
{
    public static class DIConfig
    {
        public static void RegisterWebAPIInjections(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBiblioBookService<BiblioBookDomain>, BiblioBookService>();
            services.AddScoped<IBiblioLendingInfoService<BiblioLendingInfoDomain>, BiblioLendingInfoService>();
            services.AddScoped<IBiblioReaderService<BiblioReaderDomain>, BiblioReaderService>();
            services.AddScoped<IBiblioFineService<BiblioFineDomain>, BiblioFineService>();
            services.AddScoped<IProfitReportService, ProfitReportService>();

        }
    }
}
