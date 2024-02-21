using Biblio.UtilityServices.Models.Common;

namespace Biblio.Domain.Core.Models
{
    public class BiblioBookDomain : BiblioBookModel
    {
        public ICollection<BiblioLendingInfoDomain>? BiblioLendingInfos { get; set; }
    }
}
