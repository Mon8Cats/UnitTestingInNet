using System;
using Xunit;
using SkSampleLibrary.Threads;
//using Microsoft.Diagnostics.EventFlow.TestHelpers;
using System.Threading.Tasks;

namespace SkSampleLibrary.Tests.Threads
{
    /*
    //Use DeterministicTaskScheduler
    public class Tests6
    {
        [Fact]
        public void Test_SendEmailDoesNotThrowException()
        {
            //Arrange
            DeterministicTaskScheduler taskScheduler = new DeterministicTaskScheduler();
            EmailSender6 sut = new EmailSender6(taskScheduler);
            EmailMessage message = new EmailMessage() { Message = "Hello!" };

            //Act
            sut.SendEmail(message);
            taskScheduler.RunTasksUntilIdle();

            //Assert
            //Should not throw exception
        }

        [Fact]
        public void Test_SendEmailThrowsExceptionWhenMessageIsNull()
        {
            //Arrange
            DeterministicTaskScheduler taskScheduler = new DeterministicTaskScheduler();
            EmailSender6 sut = new EmailSender6(taskScheduler);

            //Act + Assert
            sut.SendEmail(null);
            var exception = Assert.Throws<ArgumentNullException>(
                () => taskScheduler.RunTasksUntilIdle(),
                "ArgumentNullException is not thrown for null message");
            //Assert.That(exception.ParamName, Is.EqualTo("message"), "Invalid parameter name");
            Assert.Equal(exception.ParamName, "message");
        }
    }
    */
}
