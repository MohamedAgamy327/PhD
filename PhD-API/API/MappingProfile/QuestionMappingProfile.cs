using API.DTO.Question;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class QuestionMappingProfile : Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionForGetDTO>();
        }
    }
}
