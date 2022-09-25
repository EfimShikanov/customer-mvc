using CustomerDatalayer.Repositories;
using CustomerDatalayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDatalayer.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepository = new CustomerRepository();
        
        public ActionResult Index()
        {
            var customers = _customerRepository.GetAll();
            
            return View(customers);
        }

        public ActionResult Details(int customerId)
        {
            var customer = _customerRepository.Read(customerId);
            
            return View(customer);
        }

        public ActionResult Delete(int customerId)
        {
            _customerRepository.Delete(customerId);
            
            return Redirect("~/Customer/Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerRepository.Create(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return Redirect("~/Customer/Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Customer customer)
        {
            try
            {
                _customerRepository.Update(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Redirect("~/Customer/Index");
        }
    }
}

