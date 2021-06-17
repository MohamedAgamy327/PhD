using API.DTO.User;
using AutoMapper;
using Domain.Entities;

namespace API.MappingProfile
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserForAddDTO, User>();
            CreateMap<UserForEditDTO, User>();

            CreateMap<User, UserForGetDTO>();
        }
    }
}
