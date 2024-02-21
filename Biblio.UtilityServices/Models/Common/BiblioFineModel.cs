using Biblio.UtilityServices.Common.Enums;
using Biblio.UtilityServices.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Models.Common
{
    public class BiblioFineModel : BaseModel
    {
        public double FineAmount { get; set; }

        public FineReason FineReason {  get; set; } 
    }
}
