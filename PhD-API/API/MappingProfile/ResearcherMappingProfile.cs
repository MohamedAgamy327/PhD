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
                       .ForMember(dest => dest.First, opt => opt.MapFrom(src => src.First * 100))
                       .ForMember(dest => dest.Second, opt => opt.MapFrom(src => src.Second * 100))
                       .ForMember(dest => dest.Third, opt => opt.MapFrom(src => src.Third * 100))
                       .ForMember(dest => dest.Final, opt => opt.MapFrom(src => (src.Final * 100)));

            CreateMap<ResearchForRegisterDTO, Research>();
        }
    }
}
