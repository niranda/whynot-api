using AutoMapper;
using Biblio.Domain.Core.Models;
using Biblio.Infrastrusture.Data.Entities;
using Biblio.Infrastrusture.Data.Repositories;
using Biblio.Infrastrusture.Data.Stores;
using Biblio.UtilityServices.Models.Common;
using Biblio.UtilityServices.Services.BiblioBook;
using System.Globalization;
using System.Net;

namespace Biblio.Domain.Core.Services.BiblioBookS
{
    public class BiblioBookDomainService : IBiblioBookBaseService<BiblioBookDomain>
    {
        private readonly IBiblioBookRepository _biblioBookRepository;
        private readonly IBiblioLendingInfoRepository _biblioLendingInfoRepository;
        private readonly IMapper _mapper;

        public BiblioBookDomainService(
            IBiblioBookRepository biblioBookRepository,
            IBiblioLendingInfoRepository biblioLendingInfoRepository,
            IMapper mapper)
        {
            _biblioBookRepository = biblioBookRepository;
            _biblioLendingInfoRepository = biblioLendingInfoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BiblioBookDomain>> GetAllBooks()
        {
            var books = (await _biblioBookRepository.GetAll()).ToList();

            return _mapper.Map<IEnumerable<BiblioBookDomain>>(books);
        }

        public async Task<IEnumerable<PopularAnnualReportModel>> GetTopPopularBooksByYear()
        {
            var lendings = await _biblioLendingInfoRepository.GetAll();

            var groupedLendings = lendings
                .GroupBy(l => new { l.BookId, l.DateIssued.Year })
                .Select(g => new
                {
                    g.Key.BookId,
                    g.Key.Year,
                    BookAmount = g.Count(),
                    Total = g.Sum(l => l.TotalCost)
                });

            var top10Readers = groupedLendings
                .GroupBy(g => g.BookId)
                .Select(g =>
                {
                    var bookId = g.First().BookId!;
                    var book = _biblioBookRepository.GetById((Guid)bookId).GetAwaiter().GetResult();

                    return new PopularAnnualReportModel
                    {
                        Name = $"'{book.Title}' {book.Author}",
                        Year = g.First().Year,
                        BookAmount = g.Sum(r => r.BookAmount),
                        Total = g.Sum(r => r.Total)
                    };
                });

            return top10Readers.OrderByDescending(r => r.Total).Take(10);
        }

        public async Task<IEnumerable<PopularMonthlyReportModel>> GetTopPopularBooksByMonth()
        {
            var lendings = await _biblioLendingInfoRepository.GetAll();

            var groupedLendings = lendings
                .GroupBy(l => new { l.BookId, l.DateIssued.Month })
                .Select(g => new
                {
                    g.Key.BookId,
                    g.Key.Month,
                    BookAmount = g.Count(),
                    Total = g.Sum(l => l.TotalCost)
                });

            var readers = groupedLendings
                .GroupBy(g => g.BookId)
                .Select(g =>
                {
                    var bookId = g.First().BookId!;
                    var book = _biblioBookRepository.GetById((Guid)bookId).GetAwaiter().GetResult();

                    return g.Select(r => new PopularMonthlyReportModel
                    {
                        Name = $"'{book.Title}' {book.Author}",
                        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(r.Month),
                        BookAmount = r.BookAmount,
                        Total = r.Total
                    });
                });

            return readers.SelectMany(x => x)
                          .OrderByDescending(r => r.Total)
                          .Take(10);
        }

        public async Task<BiblioBookDomain> GetBookById(Guid id)
        {
            var book = await _biblioBookRepository.GetById(id);

            if (book == null)
            {
                throw new NullReferenceException(nameof(book));
            }

            return _mapper.Map<BiblioBookDomain>(book);
        }

        public async Task<BiblioBookDomain> AddBook(BiblioBookDomain book)
        {
            var biblioBook = _mapper.Map<BiblioBook>(book);

            var result = await _biblioBookRepository.Create(biblioBook);

            return _mapper.Map<BiblioBookDomain>(result);
        }

        public async Task<BiblioBookDomain> UpdateBook(BiblioBookDomain request)
        {
            var book = _mapper.Map<BiblioBook>(request);

            return _mapper.Map<BiblioBookDomain>(await _biblioBookRepository.Update(book));
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            var bookToDelete = await _biblioBookRepository.GetById(id, false);

            if (bookToDelete == null)
            {
                throw new NullReferenceException(nameof(bookToDelete));
            }

            return await _biblioBookRepository.Delete(bookToDelete);
        }
    }
}
