using Biblio.Infrastrusture.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Entities
{
    public class BiblioFine : BaseEntity
    {
        [Required]
        public double FineAmount { get; set; }

        [Required]
        public int FineReason { get; set; }

        public Guid? LendingInfoId { get; set; }
        public BiblioLendingInfo LendingInfo { get; set; }
    }
}
