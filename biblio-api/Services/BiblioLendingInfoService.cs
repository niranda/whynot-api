using Biblio.Domain.Core.Models;
using Biblio.UtilityServices.Models.Common;
using Biblio.UtilityServices.Services.BiblioLending;

namespace NomadChat.WebAPI.Services
{
    public class BiblioLendingInfoService : IBiblioLendingInfoService<BiblioLendingInfoDomain>
    {
        private readonly IBiblioLendingInfoBaseService<BiblioLendingInfoDomain> _BiblioLendingInfoDomain;
        private readonly ILogger _logger;

        public BiblioLendingInfoService(IBiblioLendingInfoBaseService<BiblioLendingInfoDomain> BiblioLendingInfoDomain, ILoggerFactory loggerFactory)
        {
            _BiblioLendingInfoDomain = BiblioLendingInfoDomain;
            _logger = loggerFactory.CreateLogger<BiblioLendingInfoService>();
        }

        public async Task<IEnumerable<BiblioLendingInfoDomain>> GetAllBookInfos()
        {
            _logger.LogInformation($"Request to get all infos");
            return await _BiblioLendingInfoDomain.GetAllBookInfos();
        }

        public async Task<IEnumerable<BiblioLendingInfoDomain>> GetAllBookInfosByReaderId(Guid readerId)
        {
            _logger.LogInformation($"Request to get all infos");
            return await _BiblioLendingInfoDomain.GetAllBookInfos();
        }

        public async Task<BiblioLendingInfoDomain> GetBookInfoByReaderIdAndBookId(GetLendingInfoRequest request)
        {
            _logger.LogInformation($"Request to get book by reader and info ids");
            return await _BiblioLendingInfoDomain.GetBookInfoByReaderIdAndBookId(request);
        }

        public async Task<BiblioLendingInfoDomain> GetBookInfoById(Guid id)
        {
            _logger.LogInformation($"Request to get info by id {id}");
            return await _BiblioLendingInfoDomain.GetBookInfoById(id);
        }

        public async Task<BiblioLendingInfoDomain> AddBookInfo(BiblioLendingInfoDomain info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            _logger.LogInformation($"Request to add an info");
            var res = await _BiblioLendingInfoDomain.AddBookInfo(info);
            return res;
        }

        public async Task<BiblioLendingInfoDomain> UpdateBookInfo(BiblioLendingInfoDomain info)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            _logger.LogInformation($"Request to update info");
            return await _BiblioLendingInfoDomain.UpdateBookInfo(info);
        }

        public async Task<bool> DeleteBookInfo(Guid id)
        {
            _logger.LogInformation($"Request to delete book");
            return await _BiblioLendingInfoDomain.DeleteBookInfo(id);
        }
    }
}
