using Moq;
using Xunit;
using SkSampleLibrary.Mocking;

namespace SkSampleLibrary.Tests.Mocking
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            var storage = new Mock<IEmployeeStorage>();
            var controller = new EmployeeController(storage.Object);

            controller.DeleteEmployee(1);
            
            storage.Verify(s => s.DeleteEmployee(1));
        }
        
    }
}