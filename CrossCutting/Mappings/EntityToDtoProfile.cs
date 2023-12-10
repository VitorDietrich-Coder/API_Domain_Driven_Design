using Api.Domain.Dtos.User;
using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UsuarioEntity>()
               .ReverseMap();

            CreateMap<UserDtoCreateResult, UsuarioEntity>()
               .ReverseMap();

            CreateMap<UserDtoUpdateResult, UsuarioEntity>()
               .ReverseMap();

        }
    }
}
