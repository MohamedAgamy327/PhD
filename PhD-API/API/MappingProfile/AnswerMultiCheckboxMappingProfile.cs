using API.DTO.AnswerMultiCheckbox;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class AnswerMultiCheckboxMappingProfile : Profile
    {
        public AnswerMultiCheckboxMappingProfile()
        {
            CreateMap<AnswerMultiCheckboxForEditDTO, AnswerMultiCheckbox>();

            CreateMap<AnswerMultiCheckbox, AnswerMultiCheckboxForGetDTO>();
        }
    }
}
