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
    public class BiblioLendingInfoRepository : IBiblioLendingInfoRepository
    {
        private readonly ApplicationContext _context;

        public BiblioLendingInfoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BiblioLendingInfo>> GetAll()
        {
            var result = await _context.BiblioLendingInfos
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Status)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<BiblioLendingInfo>> GetAllByReaderId(Guid readerId)
        {
            return await _context.BiblioLendingInfos
                .Where(x => !x.IsDeleted && x.ReaderId == readerId)
                .OrderBy(x => x.DateIssued)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<BiblioLendingInfo?> GetByReaderIdAndBookId(Guid? readerId, Guid? bookId)
        {
            return await _context.BiblioLendingInfos
                .AsNoTracking().FirstOrDefaultAsync(x => x.ReaderId == readerId && x.BookId == bookId);
        }

        public async Task<BiblioLendingInfo?> GetById(Guid id, bool asNoTracking = true)
        {
            IQueryable<BiblioLendingInfo> query = _context.BiblioLendingInfos;

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        
        public async Task<BiblioLendingInfo> Create(BiblioLendingInfo info)
        {
            await _context.BiblioLendingInfos.AddAsync(info);
            await _context.SaveChangesAsync();
            return info;
        }

        public async Task<BiblioLendingInfo> Update(BiblioLendingInfo info)
        {
            _context.BiblioLendingInfos.Update(info);
            await _context.SaveChangesAsync();
            return info;
        }

        public async Task<bool> Delete(BiblioLendingInfo info)
        {
            _context.BiblioLendingInfos.Remove(info);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
