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
                       .ForMember(dest => dest.Q8, opt => opt.MapFrom(src => src.Q8 * 100))
                       .ForMember(dest => dest.Q9, opt => opt.MapFrom(src => src.Q9 * 100))
                       .ForMember(dest => dest.Q10, opt => opt.MapFrom(src => src.Q10 * 100))
                       .ForMember(dest => dest.Q12, opt => opt.MapFrom(src => src.Q12 * 100))
                       .ForMember(dest => dest.Q13, opt => opt.MapFrom(src => src.Q13 * 100))
                       .ForMember(dest => dest.Q14, opt => opt.MapFrom(src => src.Q14 * 100))
                       .ForMember(dest => dest.Q15, opt => opt.MapFrom(src => src.Q15 * 100))
                       .ForMember(dest => dest.Q16, opt => opt.MapFrom(src => src.Q16 * 100))
                       .ForMember(dest => dest.Q17, opt => opt.MapFrom(src => src.Q17 * 100))
                       .ForMember(dest => dest.First, opt => opt.MapFrom(src => src.First * 100))
                       .ForMember(dest => dest.FirstOne, opt => opt.MapFrom(src => src.FirstOne * 100))
                       .ForMember(dest => dest.FirstTwo, opt => opt.MapFrom(src => src.FirstTwo * 100))
                       .ForMember(dest => dest.Second, opt => opt.MapFrom(src => src.Second * 100))
                       .ForMember(dest => dest.Third, opt => opt.MapFrom(src => src.Third * 100))
                       .ForMember(dest => dest.Final, opt => opt.MapFrom(src => (src.Final * 100)));

            CreateMap<ResearchForRegisterDTO, Research>();
        }
    }
}
