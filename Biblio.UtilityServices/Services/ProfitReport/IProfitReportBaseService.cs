using Biblio.UtilityServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Services.ProfitReport
{
    public interface IProfitReportBaseService
    {
        Task<IEnumerable<MonthlyReportModel>> GetMonthlyReport();
        Task<IEnumerable<AnnualReportModel>> GetAnnualReport();
    }
}
