using AbankApi.Application.Dtos.User;
using AbankApi.Domain.Entities;
using AutoMapper;

namespace AbankApi.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            // COMMANDS
            CreateMap<CreateUserDto, UserEntity>().ReverseMap();
            CreateMap<UpdateUserDto, UserEntity>().ReverseMap();

            // QUERIES 
            CreateMap<GetUserDto, UserEntity>().ReverseMap();

        }
    }
}
