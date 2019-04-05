using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using ReadStack = Infra.Mongo.Repositories;


namespace Infra.Ef.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ReadStack.CustomerRepository _customerRepository;
        private readonly Context _context;

        public CustomerRepository(
            ReadStack.CustomerRepository customerRepository,
            Context context
            ) : base(context)
        {
            _customerRepository = customerRepository;
            _context = context;
        }

        public async Task<IReadOnlyList<Customer>> GetCustomersAsync()
        {
            return await Entity
               .Include(x => x.Orders)
               .ThenInclude(x => x.Products)
               .ToListAsync();
        }

        public async Task SaveCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            await _customerRepository.SaveCustomerAsync(customer);
        }
    }
}
