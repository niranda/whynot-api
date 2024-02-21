using Biblio.UtilityServices.Common.Enums;
using Biblio.UtilityServices.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Models.Common
{
    public class BiblioLendingInfoModel : BaseModel
    {
        public DateTime DateIssued { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime EstimatedDate { get; set; }

        public LendingStatus Status { get; set; }
        public double TotalCost { get; set; }

    }
}
