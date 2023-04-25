using Microsoft.AspNetCore.Mvc;
using projClassMongoDBAPI.Models;
using projClassMongoDBAPI.Services;

namespace projClassMongoDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService; 
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);
            if(customer == null) return NotFound();
            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer) 
        {
            return _customerService.Create(customer);
            //return CreateAtRoute("GetClient" , new { id = client.id }, client);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Customer customer) 
        {
            var c = _customerService.Get(id);
            if(c == null) return NotFound();

            _customerService.Update(id, customer);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if(id ==  null) return NotFound();
            _customerService.Delete(id);
            return Ok();
        }
    }
}
