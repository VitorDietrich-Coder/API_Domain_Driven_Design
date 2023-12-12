using System;
using System.Collections.Generic;
using Api.Domain.Dtos.User;
using Domain.Dtos.User;

namespace Api.Service.Test.Usuario
{
    public class UsuarioTestes
    {
        public static string? NomeUsuario { get; set; }
        public static string? EmailUsuario { get; set; }
        public static string? NomeUsuarioAlterado { get; set; }
        public static string? EmailUsuarioAlterado { get; set; }
        public static Guid IdUsuario { get; set; }

        public List<UserDto> listaUserDto = new List<UserDto>();
        public UserDto userDto;
        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult;

        public UsuarioTestes()
        {
            IdUsuario = Guid.NewGuid();
            NomeUsuario = Faker.Name.FullName();
            EmailUsuario = Faker.Internet.Email();
            NomeUsuarioAlterado = Faker.Name.FullName();
            EmailUsuarioAlterado = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                listaUserDto.Add(dto);
            }

            userDto = new UserDto
            {
                Id = IdUsuario,
                Nome = NomeUsuario,
                Email = EmailUsuario
            };

            userDtoCreate = new UserDtoCreate
            {
                Nome = NomeUsuario,
                Email = EmailUsuario
            };


            userDtoCreateResult = new UserDtoCreateResult
            {
                Id = IdUsuario,
                Nome = NomeUsuario,
                Email = EmailUsuario,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Id = IdUsuario,
                Nome = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado
            };

            userDtoUpdateResult = new UserDtoUpdateResult
            {
                Id = IdUsuario,
                Nome = NomeUsuarioAlterado,
                Email = EmailUsuarioAlterado,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
