using Biblio.Domain.Core.Models;
using Biblio.UtilityServices.Models.Common;
using Biblio.UtilityServices.Services.BiblioDiscount;

namespace NomadChat.WebAPI.Services
{
    public class BiblioReaderService : IBiblioReaderService<BiblioReaderDomain>
    {
        private readonly IBiblioReaderBaseService<BiblioReaderDomain> _biblioReaderDomain;
        private readonly ILogger _logger;

        public BiblioReaderService(IBiblioReaderBaseService<BiblioReaderDomain> biblioReaderDomain, ILoggerFactory loggerFactory)
        {
            _biblioReaderDomain = biblioReaderDomain;
            _logger = loggerFactory.CreateLogger<BiblioReaderService>();
        }

        public async Task<IEnumerable<BiblioReaderDomain>> GetAllReaders()
        {
            _logger.LogInformation($"Request to get all readers");
            return await _biblioReaderDomain.GetAllReaders();
        }

        public async Task<IEnumerable<PopularAnnualReportModel>> GetTopPopularReadersByYear()
        {
            _logger.LogInformation($"Request to get top 10 readers by year");
            return await _biblioReaderDomain.GetTopPopularReadersByYear();
        }

        public async Task<IEnumerable<PopularMonthlyReportModel>> GetTopPopularReadersByMonth()
        {
            _logger.LogInformation($"Request to get top 10 readers by month");
            return await _biblioReaderDomain.GetTopPopularReadersByMonth();
        }

        public async Task<BiblioReaderDomain> GetReaderById(Guid id)
        {
            _logger.LogInformation($"Request to get reader by id {id}");
            return await _biblioReaderDomain.GetReaderById(id);
        }

        public async Task<BiblioReaderDomain> AddReader(BiblioReaderDomain reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            _logger.LogInformation($"Request to add a reader");
            var res = await _biblioReaderDomain.AddReader(reader);
            return res;
        }

        public async Task<BiblioReaderDomain> UpdateReader(BiblioReaderDomain reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            _logger.LogInformation($"Request to update reader");
            return await _biblioReaderDomain.UpdateReader(reader);
        }

        public async Task<bool> DeleteReader(Guid id)
        {
            _logger.LogInformation($"Request to delete reader");
            return await _biblioReaderDomain.DeleteReader(id);
        }
    }
}
