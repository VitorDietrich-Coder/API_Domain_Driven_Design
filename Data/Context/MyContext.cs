using Api.Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioEntity>(new UsuarioMap().Configure);

            modelBuilder.Entity<UsuarioEntity>().HasData(
                new UsuarioEntity 
                {
                    Id = Guid.NewGuid(),
                    Email = "ddd@teste.com",
                    Nome = "Administrador",
                    CreateAt= DateTime.Now,
                    UpdateAt = DateTime.Now,     
                });
        }
    }
}
