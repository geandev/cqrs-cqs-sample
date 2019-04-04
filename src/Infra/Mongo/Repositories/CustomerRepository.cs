using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.Models;
using MongoDB.Driver;

namespace Infra.Mongo.Repositories
{
    public class CustomerRepository : MongoRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        public async Task<IReadOnlyList<Customer>> GetCustomersAsync()
        {
            return await GetCollection().Find(_ => true).ToListAsync();
        }

        public Task SaveCustomerAsync(Customer customer)
        {
            GetCollection().InsertOne(customer);
            return Task.CompletedTask;
        }
    }
}
