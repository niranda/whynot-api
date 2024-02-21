using Biblio.UtilityServices.Services.ProfitReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NomadChat.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IProfitReportService _profitReportService;

        public ReportController(IProfitReportService profitReportService)
        {
            _profitReportService = profitReportService;
        }

        [Authorize]
        [HttpGet("Annual")]
        // GET: Readers
        public async Task<IActionResult> GetAnnualReport()
        {
            return Ok(await _profitReportService.GetAnnualReport());
        }

        [Authorize]
        [HttpGet("Monthly")]
        // GET: Readers
        public async Task<IActionResult> GetMonthlyReport()
        {
            return Ok(await _profitReportService.GetMonthlyReport());
        }
    }
}
