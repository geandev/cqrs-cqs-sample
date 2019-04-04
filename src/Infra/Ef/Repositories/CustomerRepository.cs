using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;


namespace Infra.Ef.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Customer>> GetCustomersAsync()
        {
            return await Entity
               .Include(x => x.Orders)
               .ThenInclude(x => x.Products)
               .ToListAsync();
        }

        public Task SaveCustomerAsync(Customer customer)
        {
            return _context.AddAsync(customer).ContinueWith(t => _context.SaveChangesAsync());
        }
    }
}
