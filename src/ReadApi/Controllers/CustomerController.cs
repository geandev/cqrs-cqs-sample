using Core.Models;
using Infra.Mongo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    }
}
