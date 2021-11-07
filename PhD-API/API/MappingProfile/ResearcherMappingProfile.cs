using API.DTO.Research;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class ResearcherMappingProfile : Profile
    {
        public ResearcherMappingProfile()
        {
            CreateMap<Research, ResearchForGetDTO>();
            CreateMap<Research, ResearchForResultsGetDTO>()
                       .ForMember(dest => dest.First, opt => opt.MapFrom(src => (src.Q8 + src.Q9 + src.Q10 + src.Q14 + src.Q15) / 5))
                       .ForMember(dest => dest.Second, opt => opt.MapFrom(src => (src.Q12 + src.Q13) / 2))
                       .ForMember(dest => dest.Third, opt => opt.MapFrom(src => (src.Q17 + src.Q16) / 2))
                       .ForMember(dest => dest.Final, opt => opt.MapFrom(src => (src.Q8 + src.Q9 + src.Q10 + src.Q12 + src.Q13 + src.Q14 + src.Q15 + src.Q16 + src.Q17) / 9));

            CreateMap<ResearchForRegisterDTO, Research>();
        }
    }
}
