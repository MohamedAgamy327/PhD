using API.DTO.Answer;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class AnswerMappingProfile : Profile
    {
        public AnswerMappingProfile()
        {
            CreateMap<Answer, AnswerForGetDTO>();
        }
    }
}
