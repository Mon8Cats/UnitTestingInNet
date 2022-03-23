using System;
using Xunit;
using SkSampleLibrary.Threads;

namespace SkSampleLibrary.Tests.Threads
{
    public class Tests2
    {
        [Fact]
        public void Test_SendEmailDoesNotThrowException()
        {
            //Arrange
            EmailSender2 sut = new EmailSender2();
            EmailMessage message = new EmailMessage() { Message = "Hello!" };

            //Act
            sut.SendEmailInternal(message);

            //Assert
            //Should not throw exception
        }

        [Fact]
        public void Test_SendEmailThrowsExceptionWhenMessageIsNull()
        {
            //Arrange
            EmailSender2 sut = new EmailSender2();            

            //Act + Assert
            //var exception = Assert.Throws<ArgumentNullException>( ()=> sut.SendEmailInternal(null),  "ArgumentNullException is not thrown for null message");

            //Assert.That(exception.ParamName, Is.EqualTo("message"), "Invalid parameter name");
            //Assert.Equal(exception.ParamName, "message");

            Assert.Throws<ArgumentNullException>(() => sut.SendEmailInternal(null));
        }
    }
}
