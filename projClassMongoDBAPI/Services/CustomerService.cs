using MongoDB.Driver;
using projClassMongoDBAPI.Config;
using projClassMongoDBAPI.Models;

namespace projClassMongoDBAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IProjMDSettings settings)
        {
            var customer = new MongoClient(settings.ConnectionString);
            var database = customer.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public List<Customer> Get() => _customer.Find(c => true).ToList();

        public Customer Get(string id) => _customer.Find<Customer>(c => c.Id == id).FirstOrDefault();

        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public void Update(string id, Customer customer) => _customer.ReplaceOne(c => c.Id == id, customer);

        public void Delete(Customer customer) => _customer.DeleteOne(c => c.Id == customer.Id);
        public void Delete(string id) => _customer.DeleteOne(c => c.Id == id);

    }
}
