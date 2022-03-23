using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using SkSampleLibrary.Fundamentals;

namespace SkSampleLibrary.Tests.Fundamentals
{
    public class CustomerControllerTests
    {
        [Fact]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);
            
            // NotFound 
            //Assert.That(result, Is.TypeOf<NotFound>());
            //Assert.Same(result, (NotFound));
            
            // NotFound or one of its derivatives 
            //Assert.That(result, Is.InstanceOf<NotFound>());
            Assert.True(result.GetType() == typeof(NotFound));
        }
    }
}