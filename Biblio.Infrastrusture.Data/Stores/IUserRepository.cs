using Biblio.Infrastrusture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Stores
{
    public interface IUserRepository
    {
        Task<User?> FindByUsername(string username);
        Task<IEnumerable<User>> GetAll();
        Task<Guid> Create(User user);
        Task<Guid> GetRoleId(string roleId);
    }
}
