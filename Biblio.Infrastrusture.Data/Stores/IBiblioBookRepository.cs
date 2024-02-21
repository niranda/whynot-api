using Biblio.Infrastrusture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Stores
{
    public interface IBiblioBookRepository
    {
        Task<IEnumerable<BiblioBook>> GetAll();
        Task<BiblioBook?> GetById(Guid id, bool asNoTracking = true);
        Task<BiblioBook> Create(BiblioBook message);
        Task<BiblioBook> Update(BiblioBook message);
        Task<bool> Delete(BiblioBook message);
    }
}
