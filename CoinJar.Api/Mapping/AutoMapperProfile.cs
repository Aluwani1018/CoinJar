using AutoMapper;
using CoinJar.Core.Domain;
using CoinJar.Api.Model.Requests;

namespace CoinJar.Api.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Coin, CoinRequest>()
                .ForMember(a => a.Amount, opt => opt.MapFrom(a => a.Amount))
                .ForMember(a => a.Volume, opt => opt.MapFrom(a => a.Volume)).ReverseMap();

        }
    }
}
