using Biblio.Domain.Core.Models;
using Biblio.UtilityServices.Models.Common;
using Biblio.UtilityServices.Services.BiblioBook;

namespace NomadChat.WebAPI.Services
{
    public class BiblioBookService : IBiblioBookService<BiblioBookDomain>
    {
        private readonly IBiblioBookBaseService<BiblioBookDomain> _biblioBookDomain;
        private readonly ILogger _logger;

        public BiblioBookService(IBiblioBookBaseService<BiblioBookDomain> biblioBookDomain, ILoggerFactory loggerFactory)
        {
            _biblioBookDomain = biblioBookDomain;
            _logger = loggerFactory.CreateLogger<BiblioBookService>();
        }

        public async Task<IEnumerable<BiblioBookDomain>> GetAllBooks()
        {
            _logger.LogInformation($"Request to get all books");
            return await _biblioBookDomain.GetAllBooks();
        }

        public async Task<IEnumerable<PopularAnnualReportModel>> GetTopPopularBooksByYear()
        {
            _logger.LogInformation($"Request to get top 10 books by year");
            return await _biblioBookDomain.GetTopPopularBooksByYear();
        }

        public async Task<IEnumerable<PopularMonthlyReportModel>> GetTopPopularBooksByMonth()
        {
            _logger.LogInformation($"Request to get top 10 books by month");
            return await _biblioBookDomain.GetTopPopularBooksByMonth();
        }

        public async Task<BiblioBookDomain> GetBookById(Guid id)
        {
            _logger.LogInformation($"Request to get book by id {id}");
            return await _biblioBookDomain.GetBookById(id);
        }

        public async Task<BiblioBookDomain> AddBook(BiblioBookDomain book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _logger.LogInformation($"Request to add a book");
            var res = await _biblioBookDomain.AddBook(book);
            return res;
        }

        public async Task<BiblioBookDomain> UpdateBook(BiblioBookDomain book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _logger.LogInformation($"Request to update book");
            return await _biblioBookDomain.UpdateBook(book);
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            _logger.LogInformation($"Request to delete book");
            return await _biblioBookDomain.DeleteBook(id);
        }
    }
}
