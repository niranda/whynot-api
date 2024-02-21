using AutoMapper;
using Biblio.Domain.Core.Models;
using Biblio.Infrastrusture.Data.Entities;
using Biblio.Infrastrusture.Data.Stores;
using Biblio.UtilityServices.Models.Common;
using Biblio.UtilityServices.Services.BiblioLending;

namespace Biblio.Domain.Core.Services.BiblioLendingInfoS
{
    public class BiblioLendingInfoDomainService : IBiblioLendingInfoBaseService<BiblioLendingInfoDomain>
    {
        private readonly IBiblioLendingInfoRepository _biblioLendingInfoRepository;
        private readonly IMapper _mapper;

        public BiblioLendingInfoDomainService(
            IBiblioLendingInfoRepository biblioLendingInfoRepository,
            IMapper mapper)
        {
            _biblioLendingInfoRepository = biblioLendingInfoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BiblioLendingInfoDomain>> GetAllBookInfos()
        {
            var infos = (await _biblioLendingInfoRepository.GetAll()).ToList();

            return _mapper.Map<IEnumerable<BiblioLendingInfoDomain>>(infos);
        }

        public async Task<IEnumerable<BiblioLendingInfoDomain>> GetAllBookInfosByReaderId(Guid readerId)
        {
            var infos = (await _biblioLendingInfoRepository.GetAll()).ToList();

            return _mapper.Map<IEnumerable<BiblioLendingInfoDomain>>(infos);
        }

        public async Task<BiblioLendingInfoDomain> GetBookInfoByReaderIdAndBookId(GetLendingInfoRequest request)
        {
            var info = await _biblioLendingInfoRepository.GetByReaderIdAndBookId(request.ReaderId, request.BookId);

            if (info == null)
            {
                throw new NullReferenceException(nameof(info));
            }

            return _mapper.Map<BiblioLendingInfoDomain>(info);
        }

        public async Task<BiblioLendingInfoDomain> GetBookInfoById(Guid id)
        {
            var info = await _biblioLendingInfoRepository.GetById(id);

            if (info == null)
            {
                throw new NullReferenceException(nameof(info));
            }

            return _mapper.Map<BiblioLendingInfoDomain>(info);
        }

        public async Task<BiblioLendingInfoDomain> AddBookInfo(BiblioLendingInfoDomain messageDomain)
        {
            var biblioLendingInfo = _mapper.Map<BiblioLendingInfo>(messageDomain);

            var result = await _biblioLendingInfoRepository.Create(biblioLendingInfo);

            return _mapper.Map<BiblioLendingInfoDomain>(result);
        }

        public async Task<BiblioLendingInfoDomain> UpdateBookInfo(BiblioLendingInfoDomain request)
        {
            var info = _mapper.Map<BiblioLendingInfo>(request);

            return _mapper.Map<BiblioLendingInfoDomain>(await _biblioLendingInfoRepository.Update(info));
        }

        public async Task<bool> DeleteBookInfo(Guid id)
        {
            var infoToDelete = await _biblioLendingInfoRepository.GetById(id, false);

            if (infoToDelete == null)
            {
                throw new NullReferenceException(nameof(infoToDelete));
            }

            return await _biblioLendingInfoRepository.Delete(infoToDelete);
        }
    }
}
