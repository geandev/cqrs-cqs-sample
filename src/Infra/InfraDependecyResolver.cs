using Infra.Ef;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public static class InfraDependecyResolver
    {
        public static void AddSqlInfra(this IServiceCollection services)
        {
            services.AddDbContext<Context>((serviceProvider, options) =>
                options.UseSqlServer("Server=192.168.99.100;Database=WriteDatabase;User Id=sa;Password=CqRs@setuptalk2019;", opt => opt.MigrationsAssembly("WriteApi")));

            services.AddScoped<Ef.Repositories.CustomerRepository>();

        }

        public static void AddMongoInfra(this IServiceCollection services)
        {
            services.AddScoped(s => new Mongo.Repositories.CustomerRepository("mongodb://192.168.99.100:27017", "ReadDatabase"));
        }
    }
}
