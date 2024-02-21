using Biblio.Infrastrusture.Data.Stores;
using Biblio.UtilityServices.Models.Common;
using Biblio.UtilityServices.Services.ProfitReport;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Domain.Core.Services.ProfitReport
{
    public class ProfitReportDomainService : IProfitReportBaseService
    {
        private readonly IBiblioLendingInfoRepository _lendingInfoRepository;

        public ProfitReportDomainService(IBiblioLendingInfoRepository lendingInfoRepository)
        {
            _lendingInfoRepository = lendingInfoRepository;
        }

        public async Task<IEnumerable<AnnualReportModel>> GetAnnualReport()
        {
            var startDate = DateTime.Now.AddMonths(-12);
            var endDate = DateTime.Now;

            var lendings = await _lendingInfoRepository.GetAll();

            var filteredLendings = lendings
                .Where(l => l.DateIssued >= startDate && l.DateIssued <= endDate)
                .ToList();

            var annualReports = lendings.GroupBy(l => l.DateIssued.Year)
                .Select(g => new AnnualReportModel
                {
                    Year = g.Key,
                    BookAmount = g.Count(),
                    Total = g.Sum(l => l.TotalCost)
                });

            return annualReports;
        }

        public async Task<IEnumerable<MonthlyReportModel>> GetMonthlyReport()
        {
            var startDate = DateTime.Now.AddYears(-5);
            var endDate = DateTime.Now;

            var lendings = (await _lendingInfoRepository.GetAll())
                .Where(l => l.DateIssued >= startDate && l.DateIssued <= endDate)
                .ToList();

            var monthlyReports = lendings.GroupBy(l => new { l.DateIssued.Year, l.DateIssued.Month })
                .Select(g => new MonthlyReportModel
                {
                    Month = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.Key.Month)} {g.Key.Year}",
                    BookAmount = g.Count(),
                    Total = g.Sum(l => l.TotalCost)
                });

            return monthlyReports;
        }
    }
}
