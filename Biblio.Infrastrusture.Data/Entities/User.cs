using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Biblio.Infrastrusture.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
        }

        public User(string userName, Role role)
        {
            UserName = userName;
            Role = role;
        }

        public Guid? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
