using Biblio.Infrastrusture.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Entities
{
    public class BiblioBook : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Author { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public double DepositAmount { get; set; }
        [Required]
        public double RentalCostPerDay { get; set; }

        public ICollection<BiblioLendingInfo> BiblioLendingInfos { get; set; }
    }
}
