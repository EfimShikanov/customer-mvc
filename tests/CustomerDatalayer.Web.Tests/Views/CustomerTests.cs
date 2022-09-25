using CustomerDatalayer.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDatalayer.Web.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldReturnIndexView()
        {
            CustomerController controller = new CustomerController();
            
            ViewResult result = controller.Index() as ViewResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldReturnCreateView()
        {
            CustomerController controller = new CustomerController();
            
            ViewResult result = controller.Create() as ViewResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldReturnDetailsView()
        {
            CustomerController controller = new CustomerController();
            
            ViewResult result = controller.Details(2) as ViewResult;
            
            Assert.NotNull(result);
        }
    }
}
