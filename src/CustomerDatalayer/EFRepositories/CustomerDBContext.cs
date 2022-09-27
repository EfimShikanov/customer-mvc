using System.Data.Entity;
using CustomerDatalayer.BusinessEntities;


namespace CustomerDatalayer.EFRepositories
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext()
            : base("Server=WIN-I3MNAN83JES\\SQLEXPRESS;Database=EF_CustomerLib_Shikanov;Trusted_Connection=True;")
        {
            
        }
        
        public DbSet<Customer> Customers { get; set; } = null;
    } 
}
