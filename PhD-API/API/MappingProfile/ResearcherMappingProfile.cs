using API.DTO.Researcher;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class ResearcherMappingProfile : Profile
    {
        public ResearcherMappingProfile()
        {
            CreateMap<ResearcherForRegisterDTO, Researcher>();
            //CreateMap<ResearcherForEditDTO, Researcher>();

            CreateMap<Researcher, ResearcherForGetDTO>();
        }
    }
}
