using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.Interfaces;

namespace CustomerDatalayer.EFRepositories
{
    public class EFCustomerRepository : IRepository<Customer>
    {
        private readonly CustomerDBContext _context;

        public EFCustomerRepository()
        {
            _context = new CustomerDBContext();
        }
        
        public void Create(Customer customer)
        {
            _context
                .Customers
                .Add(customer);
            
            _context.SaveChanges();
        }

        public Customer Read(int entityId)
        {
            return _context
                .Customers
                .FirstOrDefault(x => x.CustomerId == entityId);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Attach(customer);
            _context.SaveChanges();
        }

        public void Delete(int entityId)
        {
            Customer customer = Read(entityId);
            
            if (customer == null) throw new InvalidOperationException("Customer " + entityId + "does not exist");
            
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            return _context
                .Customers
                .ToList();
        }

        public void DeleteAll()
        {
            var customers = _context.Customers.ToList();
            
            foreach (var customer in customers)
            {
                _context.Customers.Remove(customer);
            }

            _context.SaveChanges();
        }
    }
}
