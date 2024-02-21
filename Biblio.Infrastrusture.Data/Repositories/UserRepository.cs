using Biblio.Infrastrusture.Data.Context;
using Biblio.Infrastrusture.Data.Entities;
using Biblio.Infrastrusture.Data.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly RoleManager<Role> _roleManager;

        public UserRepository(ApplicationContext context, RoleManager<Role> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<User?> FindByUsername(string username)
        {
            return await _context.Users
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users
                .AsNoTracking()
                .Include(x => x.Role)
                .ToListAsync();
        }

        public async Task<Guid> Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<Guid> GetRoleId(string role)
        {
            var userRole = await _roleManager.FindByNameAsync(role);
            return userRole.Id;
        }
    }
}
