using Biblio.Infrastrusture.Data.Entities;
using Biblio.UtilityServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Domain.Core.Models
{
    public class BiblioFineDomain : BiblioFineModel
    {
        public Guid? LendingInfoId { get; set; }
        public BiblioLendingInfoDomain? LendingInfo { get; set; }
    }
}
