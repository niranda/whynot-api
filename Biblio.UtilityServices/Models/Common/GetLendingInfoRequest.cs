using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Models.Common
{
    public class GetLendingInfoRequest
    {
        public Guid ReaderId { get; set; }
        public Guid BookId { get; set; }
    }
}
