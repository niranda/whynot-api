using Biblio.Domain.Core.Models;
using Biblio.UtilityServices.Services.BiblioFine;

namespace NomadChat.WebAPI.Services
{
    public class BiblioFineService : IBiblioFineService<BiblioFineDomain>
    {
        private readonly IBiblioFineBaseService<BiblioFineDomain> _biblioFineDomain;
        private readonly ILogger _logger;

        public BiblioFineService(IBiblioFineBaseService<BiblioFineDomain> biblioFineDomain, ILoggerFactory loggerFactory)
        {
            _biblioFineDomain = biblioFineDomain;
            _logger = loggerFactory.CreateLogger<BiblioFineService>();
        }

        public async Task<IEnumerable<BiblioFineDomain>> GetAllFines()
        {
            _logger.LogInformation($"Request to get all fines");
            return await _biblioFineDomain.GetAllFines();
        }

        public async Task<BiblioFineDomain> GetFineById(Guid id)
        {
            _logger.LogInformation($"Request to get fine by id {id}");
            return await _biblioFineDomain.GetFineById(id);
        }

        public async Task<BiblioFineDomain> AddFine(BiblioFineDomain fine)
        {
            if (fine == null)
            {
                throw new ArgumentNullException(nameof(fine));
            }

            _logger.LogInformation($"Request to add a book");
            var res = await _biblioFineDomain.AddFine(fine);
            return res;
        }

        public async Task<BiblioFineDomain> UpdateFine(BiblioFineDomain fine)
        {
            if (fine == null)
            {
                throw new ArgumentNullException(nameof(fine));
            }

            _logger.LogInformation($"Request to update fine");
            return await _biblioFineDomain.UpdateFine(fine);
        }

        public async Task<bool> DeleteFine(Guid id)
        {
            _logger.LogInformation($"Request to delete fine");
            return await _biblioFineDomain.DeleteFine(id);
        }
    }
}
