using API.DTO.AnswerMultiPercentage;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class AnswerMultiPercentageMappingProfile : Profile
    {
        public AnswerMultiPercentageMappingProfile()
        {
            CreateMap<AnswerMultiPercentageForEditDTO, AnswerMultiPercentage>();

            CreateMap<AnswerMultiPercentage, AnswerMultiPercentageForGetDTO>();
        }
    }
}
