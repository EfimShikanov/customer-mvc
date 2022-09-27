using CustomerDatalayer.BusinessEntities;
using CustomerDatalayer.EFRepositories;
using FluentAssertions;

namespace CustomerDatalayer.IntegrationTests.EFRepositories;

public class EFCustomerRepositoryTest
{
    [Fact]
    public void ShouldBeAbleToCreateCustomerRepository()
    {
        EFCustomerRepository repository = new EFCustomerRepository();
        repository.Should().NotBeNull();
    }

    [Fact]
    public void ShouldBeAbleToCreateCustomer()
    {
        EFCustomerRepository repository = new EFCustomerRepository();
        repository.DeleteAll();
        repository.Create(CustomerRepositoryFixture.GetCustomer());
    }

    [Fact]
    public void ShouldBeAbleToReadCustomer()
    {
        EFCustomerRepository repository = new EFCustomerRepository();
        repository.DeleteAll();
        Customer customer = CustomerRepositoryFixture.GetCustomer();
        
        repository.Create(customer);
        var result = repository.Read(customer.CustomerId);
        
        Assert.NotNull(result);
        Assert.Equal("Harold", result.FirstName);
    }

    [Fact]
    public void ShouldBeAbleToDeleteCustomer()
    {
        EFCustomerRepository repository = new EFCustomerRepository();
        repository.DeleteAll();
        Customer customer = CustomerRepositoryFixture.GetCustomer();
        
        repository.Create(customer);
        repository.Delete(customer.CustomerId);
    }

    private class CustomerRepositoryFixture
    {
        public static Customer GetCustomer()
        {
            var customer = new Customer
            {
                FirstName = "Harold",
                LastName = "Johnson",
                PhoneNumber = "12673935933",
                Email = "HaroldSJohnson@armyspy.com",
                TotalPurchasesAmount = 0
            };

            return customer;
        }
    }
}