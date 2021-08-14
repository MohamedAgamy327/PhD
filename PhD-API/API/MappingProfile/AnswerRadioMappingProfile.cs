using API.DTO.AnswerRadio;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class AnswerRadioMappingProfile : Profile
    {
        public AnswerRadioMappingProfile()
        {
            CreateMap<AnswerRadioForEditDTO, AnswerRadio>();

            CreateMap<AnswerRadio, AnswerRadioForGetDTO>();
        }
    }
}
