using AutoMapper;
using Biblio.Domain.Core.Models;
using Biblio.Infrastrusture.Data.Entities;
using Biblio.Infrastrusture.Data.Stores;
using Biblio.UtilityServices.Services.BiblioFine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Domain.Core.Services.BiblioFineS
{
    public class BiblioFineDomainService : IBiblioFineBaseService<BiblioFineDomain>
    {
        private readonly IBiblioFineRepository _biblioFineRepository;
        private readonly IMapper _mapper;

        public BiblioFineDomainService(
            IBiblioFineRepository biblioFineRepository,
            IMapper mapper)
        {
            _biblioFineRepository = biblioFineRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BiblioFineDomain>> GetAllFines()
        {
            var fines = (await _biblioFineRepository.GetAll()).ToList();

            return _mapper.Map<IEnumerable<BiblioFineDomain>>(fines);
        }

        public async Task<BiblioFineDomain> GetFineById(Guid id)
        {
            var fine = await _biblioFineRepository.GetById(id);

            if (fine == null)
            {
                throw new NullReferenceException(nameof(fine));
            }

            return _mapper.Map<BiblioFineDomain>(fine);
        }

        public async Task<BiblioFineDomain> AddFine(BiblioFineDomain request)
        {
            var BiblioFine = _mapper.Map<BiblioFine>(request);

            var result = await _biblioFineRepository.Create(BiblioFine);

            return _mapper.Map<BiblioFineDomain>(result);
        }

        public async Task<BiblioFineDomain> UpdateFine(BiblioFineDomain request)
        {
            var fine = _mapper.Map<BiblioFine>(request);

            return _mapper.Map<BiblioFineDomain>(await _biblioFineRepository.Update(fine));
        }

        public async Task<bool> DeleteFine(Guid id)
        {
            var fineToDelete = await _biblioFineRepository.GetById(id, false);

            if (fineToDelete == null)
            {
                throw new NullReferenceException(nameof(fineToDelete));
            }

            return await _biblioFineRepository.Delete(fineToDelete);
        }
    }
}
