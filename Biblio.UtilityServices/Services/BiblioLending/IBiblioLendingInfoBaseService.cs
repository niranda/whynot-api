using Biblio.UtilityServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Services.BiblioLending
{
    public interface IBiblioLendingInfoBaseService<T>
    {
        Task<IEnumerable<T>> GetAllBookInfos();
        Task<IEnumerable<T>> GetAllBookInfosByReaderId(Guid readerId);
        Task<T> GetBookInfoByReaderIdAndBookId(GetLendingInfoRequest request);
        Task<T> GetBookInfoById(Guid id);
        Task<T> AddBookInfo(T message);
        Task<T> UpdateBookInfo(T message);
        Task<bool> DeleteBookInfo(Guid id);
    }
}
