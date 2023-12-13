using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using API_Domain_Driven_Design.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Services.User;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarCreate
{
    public class Retorno_BadRequest
    {
        private UsersControllers _controller;
        [Fact(DisplayName = "É possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersControllers(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um Campo Obrigatório");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate
            {
                Nome = nome,
                Email = email,
            };

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
