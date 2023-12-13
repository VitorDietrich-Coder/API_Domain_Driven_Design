using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using API_Domain_Driven_Design.Controllers;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Services.User;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarGet
{
    public class Retorno_Get
    {
        private UsersControllers _controller;

        [Fact(DisplayName = "É possível Realizar o Get.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                 new UserDto
                 {
                     Id = Guid.NewGuid(),
                     Nome = nome,
                     Email = email,
                     CreateAt = DateTime.UtcNow
                 }
            );

            _controller = new UsersControllers(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(nome, resultValue.Nome);
            Assert.Equal(email, resultValue.Email);

        }
    }
}
