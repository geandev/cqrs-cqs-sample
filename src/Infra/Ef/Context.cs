using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
