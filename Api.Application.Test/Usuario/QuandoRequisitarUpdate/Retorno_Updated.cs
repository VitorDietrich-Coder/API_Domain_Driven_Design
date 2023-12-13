using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using API_Domain_Driven_Design.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Services.User;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarUpdate
{
    public class Retorno_Updated
    {
        private UsersControllers _controller;

        [Fact(DisplayName = "É possível Realizar o Updated.")]
        public async Task E_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    Email = email,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersControllers(serviceMock.Object);

            var userDtoUpdate = new UserDtoUpdate
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Email = email,
            };

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is OkObjectResult);

            UserDtoUpdateResult resultValue = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(userDtoUpdate.Nome, resultValue.Nome);
            Assert.Equal(userDtoUpdate.Email, resultValue.Email);
        }
    }
}
