using Biblio.Infrastrusture.Data.Entities;
using Biblio.UtilityServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Domain.Core.Models
{
    public class BiblioReaderDomain : BiblioReaderModel
    {
        public ICollection<BiblioLendingInfoDomain>? BiblioLendingInfos { get; set; }
        public ICollection<BiblioFineDomain>? BiblioFines { get; set; }
    }
}
