using Biblio.Infrastrusture.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Infrastrusture.Data.Entities
{
    public class BiblioReader : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public double? DiscountAmount { get; set; }

        public ICollection<BiblioLendingInfo> BiblioLendingInfos { get; set; }
        public ICollection<BiblioFine> BiblioFines { get; set; }
    }
}
