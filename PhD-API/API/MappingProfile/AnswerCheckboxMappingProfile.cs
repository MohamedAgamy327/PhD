using API.DTO.AnswerCheckbox;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class AnswerCheckboxMappingProfile : Profile
    {
        public AnswerCheckboxMappingProfile()
        {
            CreateMap<AnswerCheckboxForEditDTO, AnswerCheckbox>();

            CreateMap<AnswerCheckbox, AnswerCheckboxForGetDTO>();
        }
    }
}
