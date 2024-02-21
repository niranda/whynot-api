using Biblio.Infrastrusture.Data.Context;
using Biblio.Infrastrusture.Data.Entities;
using Biblio.Infrastrusture.Data.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Repositories
{
    public class BiblioFineRepository : IBiblioFineRepository
    {
        private readonly ApplicationContext _context;

        public BiblioFineRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BiblioFine>> GetAll()
        {
            return await _context.BiblioFines
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.FineAmount)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<BiblioFine?> GetById(Guid id, bool asNoTracking = true)
        {
            IQueryable<BiblioFine> query = _context.BiblioFines;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<BiblioFine> Create(BiblioFine fine)
        {
            await _context.BiblioFines.AddAsync(fine);
            await _context.SaveChangesAsync();
            return fine;
        }

        public async Task<BiblioFine> Update(BiblioFine fine)
        {
            _context.BiblioFines.Update(fine);
            await _context.SaveChangesAsync();
            return fine;
        }

        public async Task<bool> Delete(BiblioFine fine)
        {
            _context.BiblioFines.Remove(fine);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
