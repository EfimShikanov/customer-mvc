using CustomerDatalayer.Web.Controllers;
using FluentAssertions;

namespace CustomerDatalayer.Web.Tests
{
    public class CustomerControllerTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerController()
        {
            var controller = new CustomerController();

            controller.Should().NotBeNull();
        }
        
    }
}

