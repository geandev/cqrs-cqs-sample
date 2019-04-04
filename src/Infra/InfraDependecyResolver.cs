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
                options.UseSqlServer("Server=write-database;Database=WriteDatabase;User Id=setuptalk;Password=cqrs;"));
            services.AddScoped<Ef.Repositories.CustomerRepository>();

        }

        public static void AddMongoInfra(this IServiceCollection services)
        {
            services.AddScoped(s => new Mongo.Repositories.CustomerRepository("mongodb://read-databse:27017", "ReadDatabase"));
        }
    }
}
