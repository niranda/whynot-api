using Biblio.UtilityServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Services.BiblioDiscount
{
    public interface IBiblioReaderBaseService<T>
    {
        Task<IEnumerable<T>> GetAllReaders();
        Task<IEnumerable<PopularAnnualReportModel>> GetTopPopularReadersByYear();
        Task<IEnumerable<PopularMonthlyReportModel>> GetTopPopularReadersByMonth();
        Task<T> GetReaderById(Guid id);
        Task<T> AddReader(T message);
        Task<T> UpdateReader(T message);
        Task<bool> DeleteReader(Guid id);
    }
}
