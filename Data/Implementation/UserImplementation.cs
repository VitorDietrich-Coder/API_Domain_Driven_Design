using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Implementation
{
    public class UserImplementation : BaseRepository<UsuarioEntity>, IUserRepository
    {
        private DbSet<UsuarioEntity> _dataSet;

        public UserImplementation(MyContext myContext): base(myContext) 
        {
            _dataSet =_context.Set<UsuarioEntity>();
        }

        public async Task<UsuarioEntity> FindByLogin(string email)
        {
            return await _dataSet.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
