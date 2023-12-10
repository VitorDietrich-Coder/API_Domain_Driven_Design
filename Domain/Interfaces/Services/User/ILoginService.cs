using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto loginDto);
    }
}