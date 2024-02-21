using Biblio.Infrastrusture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Stores
{
    public interface IBiblioReaderRepository
    {
        Task<IEnumerable<BiblioReader>> GetAll();
        Task<BiblioReader?> GetById(Guid id, bool asNoTracking = true);
        Task<BiblioReader> Create(BiblioReader message);
        Task<BiblioReader> Update(BiblioReader message);
        Task<bool> Delete(BiblioReader message);
    }
}
