using Biblio.Infrastrusture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Stores
{
    public interface IBiblioFineRepository
    {
        Task<IEnumerable<BiblioFine>> GetAll();
        Task<BiblioFine?> GetById(Guid id, bool asNoTracking = true);
        Task<BiblioFine> Create(BiblioFine message);
        Task<BiblioFine> Update(BiblioFine message);
        Task<bool> Delete(BiblioFine message);
    }
}
