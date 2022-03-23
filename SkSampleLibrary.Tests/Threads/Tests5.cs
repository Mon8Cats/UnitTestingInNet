using System;
using Xunit;
using SkSampleLibrary.Threads;

namespace SkSampleLibrary.Tests.Threads
{
    //Test with humble object pattern
    
    public class Tests5
    {
        [Fact]
        public void Test_SendEmailDoesNotThrowException()
        {
            //Arrange
            SendEmailOperation sut = new SendEmailOperation();
            EmailMessage message = new EmailMessage() { Message = "Hello" };
            //Act
            sut.Send(message);
            //Assert -> Should not throw exception
        }

        [Fact]
        public void Test_SendEmailThrowsExceptionWhenMessageIsNull()
        {
            //Arrange
            SendEmailOperation sut = new SendEmailOperation();
            //Act + Assert
            //var exception = Assert.Throws<ArgumentNullException>(() => sut.Send(null), "ArgumentNullException is not thrown for null message");

            //Assert.That(exception.ParamName, Is.EqualTo("message"), "Invalid parameter name");
            //Assert.Equal(exception.ParamName, "message");
            Assert.Throws<ArgumentNullException>(() => sut.Send(null));
        }
    }
    
}
