using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Models.Common
{
    public class AnnualReportModel
    {
        public int Year { get; set; }
        public int BookAmount { get; set; }
        public double Total { get; set; }
    }
}
