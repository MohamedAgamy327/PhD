using API.DTO.AnswerNumber;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class AnswerNumberMappingProfile : Profile
    {
        public AnswerNumberMappingProfile()
        {
            CreateMap<AnswerNumberForEditDTO, AnswerNumber>();

            CreateMap<AnswerNumber, AnswerNumberForGetDTO>();
        }
    }
}
