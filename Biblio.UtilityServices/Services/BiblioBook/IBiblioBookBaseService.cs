using Biblio.UtilityServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Services.BiblioBook
{
    public interface IBiblioBookBaseService<T>
    {
        Task<IEnumerable<T>> GetAllBooks();
        Task<IEnumerable<PopularAnnualReportModel>> GetTopPopularBooksByYear();
        Task<IEnumerable<PopularMonthlyReportModel>> GetTopPopularBooksByMonth();
        Task<T> GetBookById(Guid id);
        Task<T> AddBook(T message);
        Task<T> UpdateBook(T message);
        Task<bool> DeleteBook(Guid id);
    }
}
