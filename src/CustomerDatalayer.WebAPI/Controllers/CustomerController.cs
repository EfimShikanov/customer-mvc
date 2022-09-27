using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.EFRepositories;
using CustomerDatalayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDatalayer.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;
        public CustomerController()
        {
            _repository = new EFCustomerRepository();
        }

        [HttpGet]
        public ActionResult GetAllCustomers()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            if (customer == null) return BadRequest("Customer can not be empty");
            
            _repository.Create(customer);

            return Ok(_repository.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult GetCustomer(int id)
        {
            var customer = _repository.Read(id);
            
            if (customer == null) return NotFound(id);
            
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            if (customer == null) return BadRequest("Customer can not be empty");
            
            _repository.Update(customer);
            
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult DeleteCustomer(int id)
        {
            _repository.Delete(id);

            return Ok(_repository.GetAll());
        }
    }
}
