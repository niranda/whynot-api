using Biblio.Infrastrusture.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Entities
{
    public class BiblioLendingInfo : BaseEntity
    {
        [Required]
        public DateTime DateIssued { get; set; }

        public DateTime? EndDate { get; set; }
        [Required]
        public DateTime EstimatedDate { get; set; }
        [Required]
        public int Status { get; set; }

        public double TotalCost {  get; set; }

        public Guid? ReaderId { get; set; }
        public BiblioReader Reader { get; set; }

        public Guid? BookId { get; set; }
        public BiblioBook Book { get; set; }

        public Guid? FineId { get; set; }
        public BiblioFine Fine { get; set; }

    }
}
