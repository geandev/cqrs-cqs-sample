using Core.Models;
using Infra.Ef.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WriteApi.Controllers
{
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Customer>> GetCustomersAsync()
        {
            return await _customerRepository.GetCustomersAsync();
        }

        [HttpPost]
        public async Task SaveCustomerAsync()
        {
            var customer = new Customer
            {
                Name = "Gean Silva",
                Age = 18,
                Orders = Enumerable.Range(0, 10).Select(o => new Order
                {
                    Products = Enumerable.Range(0, 3).Select(p => new Product { Name = $"Product {p}", Value = p }).ToList()

                }).ToList()
            };

            await _customerRepository.SaveCustomerAsync(customer);
        }

    }
}
