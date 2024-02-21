using Biblio.UtilityServices.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Biblio.UtilityServices.Models.Common
{
    public class BiblioBookModel : BaseModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public bool IsAvailable { get; set; }

        public double RentalCostPerDay { get; set; }

        public double DepositAmount { get; set; }
    }
}
