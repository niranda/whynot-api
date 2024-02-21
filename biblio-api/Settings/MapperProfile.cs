using AutoMapper;
using Biblio.Domain.Core.Models;
using Biblio.Infrastrusture.Data.Entities;

namespace NomadChat.WebAPI.Settings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BiblioBook, BiblioBookDomain>().ReverseMap();
            CreateMap<BiblioFine, BiblioFineDomain>().ReverseMap();
            CreateMap<BiblioLendingInfo, BiblioLendingInfoDomain>().ReverseMap();
            CreateMap<BiblioReader, BiblioReaderDomain>().ReverseMap();
        }
    }
}
