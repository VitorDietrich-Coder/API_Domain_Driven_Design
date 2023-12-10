using Data.Context;
using Data.Implementation;
using Data.Repository;
using Domain.Interfaces;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            // serviceCollection.AddDbContext<MyContext> (
            //     options => options.UseMySql ("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=mudar@123")
            // );

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Server=.;Database=DB_Api_DDD;Trusted_Connection=True;MultipleActiveResultSets=true;")
            );
        }
    }
}