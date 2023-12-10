using Api.Domain.Models;
using AutoMapper;
using Domain.Entities;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UsuarioEntity>()
               .ReverseMap();
        }
    }
}
