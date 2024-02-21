using Biblio.Infrastrusture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Stores
{
    public interface IBiblioLendingInfoRepository
    {
        Task<IEnumerable<BiblioLendingInfo>> GetAll();
        Task<IEnumerable<BiblioLendingInfo>> GetAllByReaderId(Guid readerId);
        Task<BiblioLendingInfo?> GetById(Guid id, bool asNoTracking = true);
        Task<BiblioLendingInfo?> GetByReaderIdAndBookId(Guid? readerId, Guid? bookId);
        Task<BiblioLendingInfo> Create(BiblioLendingInfo message);
        Task<BiblioLendingInfo> Update(BiblioLendingInfo message);
        Task<bool> Delete(BiblioLendingInfo message);
    }
}
