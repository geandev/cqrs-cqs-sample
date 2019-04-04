using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Customer>> GetCustomersAsync();
        Task SaveCustomerAsync(Customer customer);
    }
}
