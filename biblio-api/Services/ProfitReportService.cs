using Biblio.UtilityServices.Models.Common;
using Biblio.UtilityServices.Services.ProfitReport;

namespace NomadChat.WebAPI.Services
{
    public class ProfitReportService : IProfitReportService
    {
        private readonly IProfitReportBaseService _profitReportService;

        public ProfitReportService(IProfitReportBaseService profitReportService)
        {
            _profitReportService = profitReportService;
        }

        public async Task<IEnumerable<AnnualReportModel>> GetAnnualReport()
        {
            return await _profitReportService.GetAnnualReport();
        }

        public async Task<IEnumerable<MonthlyReportModel>> GetMonthlyReport()
        {
            return await _profitReportService.GetMonthlyReport();
        }
    }
}
