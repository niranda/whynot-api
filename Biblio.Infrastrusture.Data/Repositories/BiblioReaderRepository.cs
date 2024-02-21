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
    public class BiblioReaderRepository : IBiblioReaderRepository
    {
        private readonly ApplicationContext _context;

        public BiblioReaderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BiblioReader>> GetAll()
        {
            return await _context.BiblioReaders
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.DiscountAmount)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<BiblioReader?> GetById(Guid id, bool asNoTracking = true)
        {
            IQueryable<BiblioReader> query = _context.BiblioReaders;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query
                .Include(s => s.BiblioLendingInfos)
                .Include(s => s.BiblioFines)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<BiblioReader> Create(BiblioReader reader)
        {
            await _context.BiblioReaders.AddAsync(reader);
            await _context.SaveChangesAsync();
            return reader;
        }

        public async Task<BiblioReader> Update(BiblioReader reader)
        {
            _context.BiblioReaders.Update(reader);
            await _context.SaveChangesAsync();
            return reader;
        }

        public async Task<bool> Delete(BiblioReader reader)
        {
            _context.BiblioReaders.Remove(reader);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
