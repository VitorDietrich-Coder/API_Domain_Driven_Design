using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository : IRepository<UsuarioEntity>
    {
        Task<UsuarioEntity> FindByLogin(string email);
    }
}
