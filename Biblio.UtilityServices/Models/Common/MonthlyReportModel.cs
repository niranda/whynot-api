using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.UtilityServices.Models.Common
{
    public class MonthlyReportModel
    {
        public string Month {  get; set; }
        public double BookAmount { get; set; }
        public double Total { get; set; }
    }
}
