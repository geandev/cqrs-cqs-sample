using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Ef
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
