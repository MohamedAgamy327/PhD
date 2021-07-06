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
            CreateMap<ResearchForRegisterDTO, Research>();
        }
    }
}
