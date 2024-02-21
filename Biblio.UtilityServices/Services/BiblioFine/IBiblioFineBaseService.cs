using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Services.BiblioFine
{
    public interface IBiblioFineBaseService<T>
    {
        Task<IEnumerable<T>> GetAllFines();
        Task<T> GetFineById(Guid id);
        Task<T> AddFine(T message);
        Task<T> UpdateFine(T message);
        Task<bool> DeleteFine(Guid id);
    }
}
