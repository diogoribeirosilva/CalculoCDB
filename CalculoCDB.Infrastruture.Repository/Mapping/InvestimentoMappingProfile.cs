using AutoMapper;
using CalculoCDB.Application.DTO.DTO;
using CalculoCDB.Domain.Models;

namespace CalculoCDB.Infrastruture.Repository.Mapping
{
    public class InvestimentoMappingProfile : Profile
    {
        public InvestimentoMappingProfile()
        {
            CreateMap<Investimento, InvestimentoDto>()
                .ForMember(dest => dest.ValorBruto, opt => opt.MapFrom(src => src.ValorBruto))
                .ForMember(dest => dest.ValorLiquido, opt => opt.MapFrom(src => src.ValorLiquido));
        }
    }
}
