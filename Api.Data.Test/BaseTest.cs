using Api.Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        { 
        
        }
    }

    public class DbTeste : IDisposable
    {
        private string DatabaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    
        public ServiceProvider? ServiceProvider { get; private set; }

        public DbTeste()
        {
        var serviceCollection = new ServiceCollection();    
        serviceCollection.AddDbContext<MyContext>(
            o => o.UseSqlServer($"Server=.;Database={DatabaseName};Trusted_Connection=True;MultipleActiveResultSets=true;"), ServiceLifetime.Transient
        );
            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();

                context.Usuarios.Add(new UsuarioEntity
                {
                    Id = Guid.NewGuid(),
                    Email = "ddd@teste.com",
                    Nome = "Administrador",
                    Telefone = "45 99848445",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                });

                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
