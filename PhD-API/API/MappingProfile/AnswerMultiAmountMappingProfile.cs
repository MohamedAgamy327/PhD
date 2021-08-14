using API.DTO.AnswerMultiAmount;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class AnswerMultiAmountMappingProfile : Profile
    {
        public AnswerMultiAmountMappingProfile()
        {
            CreateMap<AnswerMultiAmountForEditDTO, AnswerMultiAmount>();

            CreateMap<AnswerMultiAmount, AnswerMultiAmountForGetDTO>();
        }
    }
}
