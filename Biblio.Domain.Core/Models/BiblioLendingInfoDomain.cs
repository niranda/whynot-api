using Biblio.Infrastrusture.Data.Entities;
using Biblio.UtilityServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Domain.Core.Models
{
    public class BiblioLendingInfoDomain : BiblioLendingInfoModel
    {
        public Guid? ReaderId { get; set; }
        public BiblioReaderDomain? Reader { get; set; }

        public Guid? BookId { get; set; }
        public BiblioBookDomain? Book { get; set; }

        public Guid? FineId { get; set; }
        public BiblioFine? Fine { get; set; }
    }
}
