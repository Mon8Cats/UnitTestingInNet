using Moq;
using Xunit;
using SkSampleLibrary.Mocking;

namespace SkSampleLibrary.Tests.Mocking
{
    public class ProductTests
    {
        [Fact]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            var product = new Product {ListPrice = 100};

            var result = product.GetPrice(new Customer {IsGold = true});
            
            Assert.Equal(result, 70);
        } 
        
        [Fact]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount2()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(c => c.IsGold).Returns(true);
            
            var product = new Product {ListPrice = 100};

            var result = product.GetPrice(customer.Object);
            
            Assert.Equal(result, 70);
        }
        
    }
}