using Biblio.Infrastrusture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastructure.Business.Services.Token
{
    public interface ITokenService
    {
        string GenerateJWT(User user);
    }
}
