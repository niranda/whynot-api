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
    public class BiblioBookRepository : IBiblioBookRepository
    {
        private readonly ApplicationContext _context;

        public BiblioBookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BiblioBook>> GetAll()
        {
            return await _context.BiblioBooks
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Title)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<BiblioBook?> GetById(Guid id, bool asNoTracking = true)
        {
            IQueryable<BiblioBook> query = _context.BiblioBooks;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<BiblioBook> Create(BiblioBook book)
        {
            await _context.BiblioBooks.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<BiblioBook> Update(BiblioBook book)
        {
            _context.BiblioBooks.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> Delete(BiblioBook book)
        {
            var lendingInfos = await _context.BiblioLendingInfos
            .Where(lendingInfo => lendingInfo.BookId == book.Id)
            .ToListAsync();


            foreach (var lendingInfo in lendingInfos)
            {
                lendingInfo.BookId = null;
            }

            _context.BiblioBooks.Remove(book);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
