using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using API_Domain_Driven_Design.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Services.User;
using Xunit;

namespace Api.Application.Test.Usuario.QuandoRequisitarDelete
{
    public class Retorno_BadRequest
    {
        private UsersControllers _controller;

        [Fact(DisplayName = "É possível Realizar o Deleted.")]
        public async Task E_Possivel_Invocar_a_Controller_Delete()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                       .ReturnsAsync(false);

            _controller = new UsersControllers(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
