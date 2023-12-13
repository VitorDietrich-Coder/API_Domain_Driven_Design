using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using API_Domain_Driven_Design.Controllers;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Services.User;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGetAll
{
    public class Retorno_BadRequest
    {
        private UsersControllers _controller;

        [Fact(DisplayName = "É possível Realizar o GetAll.")]
        public async Task E_Possivel_Invocar_a_Controller_GetAll()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                 new List<UserDto>
                 {
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    },
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    }
                 }
            );
            _controller = new UsersControllers(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
