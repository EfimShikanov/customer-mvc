using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.EFRepositories;
using CustomerDatalayer.Interfaces;

namespace CustomerDatalayer.Tests.EFRepositories
{
    public class EFRepositoryTest
    {
        [Fact]
        public void ShouldCreateCustomerRepository()
        {
            var efRepository = new EFCustomerRepository();
            Assert.NotNull(efRepository);
            Assert.IsAssignableFrom<IRepository<Customer>>(efRepository);
        }
    } 
}

