using Biblio.UtilityServices.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Models.Common
{
    public class BiblioReaderModel : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public double? DiscountAmount { get; set; }
    }
}
