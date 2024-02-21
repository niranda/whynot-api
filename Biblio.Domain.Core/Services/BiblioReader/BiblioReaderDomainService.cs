using AutoMapper;
using Biblio.Domain.Core.Models;
using Biblio.Infrastrusture.Data.Entities;
using Biblio.Infrastrusture.Data.Repositories;
using Biblio.Infrastrusture.Data.Stores;
using Biblio.UtilityServices.Models.Common;
using Biblio.UtilityServices.Services.BiblioDiscount;
using System.Globalization;

namespace Biblio.Domain.Core.Services.BiblioReaderS
{
    public class BiblioReaderDomainService : IBiblioReaderBaseService<BiblioReaderDomain>
    {
        private readonly IBiblioReaderRepository _biblioReaderRepository;
        private readonly IBiblioLendingInfoRepository _biblioLendingInfoRepository;
        private readonly IMapper _mapper;

        public BiblioReaderDomainService(
            IBiblioReaderRepository biblioReaderRepository,
            IBiblioLendingInfoRepository biblioLendingInfoRepository,
            IMapper mapper)
        {
            _biblioReaderRepository = biblioReaderRepository;
            _biblioLendingInfoRepository = biblioLendingInfoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BiblioReaderDomain>> GetAllReaders()
        {
            var biblioReaders = (await _biblioReaderRepository.GetAll()).ToList();

            return _mapper.Map<IEnumerable<BiblioReaderDomain>>(biblioReaders);
        }

        public async Task<IEnumerable<PopularAnnualReportModel>> GetTopPopularReadersByYear()
        {
            var lendings = await _biblioLendingInfoRepository.GetAll();

            var groupedLendings = lendings
                .GroupBy(l => new { l.ReaderId, l.DateIssued.Year })
                .Select(g => new
                {
                    g.Key.ReaderId,
                    g.Key.Year,
                    BookAmount = g.Count(),
                    Total = g.Sum(l => l.TotalCost)
                });

            var top10Readers = groupedLendings
                .GroupBy(g => g.ReaderId)
                .Select(g =>
                {
                    var readerId = g.First().ReaderId!;
                    var reader = _biblioReaderRepository.GetById((Guid)readerId).GetAwaiter().GetResult();

                    return new PopularAnnualReportModel
                    {
                        Name = $"{reader.FirstName} {reader.LastName}",
                        Year = g.First().Year,
                        BookAmount = g.Sum(r => r.BookAmount),
                        Total = g.Sum(r => r.Total)
                    };
                });

            return top10Readers.OrderByDescending(r => r.Total).Take(10);
        }

        public async Task<IEnumerable<PopularMonthlyReportModel>> GetTopPopularReadersByMonth()
        {
            var lendings = await _biblioLendingInfoRepository.GetAll();

            var groupedLendings = lendings
                .GroupBy(l => new { l.ReaderId, l.DateIssued.Month })
                .Select(g => new
                {
                    g.Key.ReaderId,
                    g.Key.Month,
                    BookAmount = g.Count(),
                    Total = g.Sum(l => l.TotalCost)
                });

            var readers = groupedLendings
                .GroupBy(g => g.ReaderId)
                .Select(g =>
                {
                    var readerId = g.First().ReaderId!;
                    var reader = _biblioReaderRepository.GetById((Guid)readerId).GetAwaiter().GetResult();

                    return g.Select(r => new PopularMonthlyReportModel
                    {
                        Name = $"{reader.FirstName} {reader.LastName}",
                        Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(r.Month),
                        BookAmount = r.BookAmount,
                        Total = r.Total
                    });
                });

            return readers.SelectMany(x => x)
                          .OrderByDescending(r => r.Total)
                          .Take(10);
        }

        public async Task<BiblioReaderDomain> GetReaderById(Guid id)
        {
            var message = await _biblioReaderRepository.GetById(id);

            if (message == null)
            {
                throw new NullReferenceException(nameof(message));
            }

            return _mapper.Map<BiblioReaderDomain>(message);
        }

        public async Task<BiblioReaderDomain> AddReader(BiblioReaderDomain requestModel)
        {
            var biblioReader = _mapper.Map<BiblioReader>(requestModel);

            var result = await _biblioReaderRepository.Create(biblioReader);

            return _mapper.Map<BiblioReaderDomain>(result);
        }

        public async Task<BiblioReaderDomain> UpdateReader(BiblioReaderDomain requestModel)
        {
            var biblioReader = _mapper.Map<BiblioReader>(requestModel);

            return _mapper.Map<BiblioReaderDomain>(await _biblioReaderRepository.Update(biblioReader));
        }

        public async Task<bool> DeleteReader(Guid id)
        {
            var biblioReaderToDelete = await _biblioReaderRepository.GetById(id, false);

            if (biblioReaderToDelete == null)
            {
                throw new NullReferenceException(nameof(biblioReaderToDelete));
            }

            return await _biblioReaderRepository.Delete(biblioReaderToDelete);
        }
    }
}
