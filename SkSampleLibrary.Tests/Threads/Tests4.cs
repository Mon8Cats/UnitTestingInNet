using System;
using System.Threading;
using Xunit;
using SkSampleLibrary.Threads;
using Moq;

namespace SkSampleLibrary.Tests.Threads
{
    
    public class Tests4
    {
        [Fact]
        public void Test_MessageSentCalledWithCorrectMessage()
        {
            //Arrange
            var waitHandle = new ManualResetEventSlim(false);
            EmailMessage message = new EmailMessage() { Message = "Hello" };
            EmailMessage sentMessage = null;
            var mockCallback = new Mock<IThreadCallback>();
            mockCallback.Setup(m => m.OnMessageSent(It.IsAny<EmailMessage>()))
                .Callback<EmailMessage>((msg)=> 
                {
                    sentMessage = msg;
                    waitHandle.Set();
                });

            EmailSender4 sut = new EmailSender4(mockCallback.Object);

            //Act
            sut.SendEmail(message);
            bool callbackCalled = waitHandle.Wait(2000);

            //Assert
            //Assert.That(callbackCalled, Is.EqualTo(true),  "OnMessageSent callback not called");
            //Assert.That(sentMessage, Is.EqualTo(message),  "OnMessageSent called with wrong message");
            Assert.Equal(callbackCalled, true);
            Assert.Equal(sentMessage, message);
        }

        [Fact]
        public void Test_OnFailureCalledWhenMessageIsNull()
        {
            //Arrange
            var waitHandle = new ManualResetEventSlim(false);
            EmailMessage sentMessage = null;
            Exception thrownException = null;
            var mockCallback = new Mock<IThreadCallback>();
            mockCallback.Setup(m => m.OnFailure(It.IsAny<EmailMessage>(), It.IsAny<Exception>()))
                .Callback<EmailMessage, Exception>((msg, ex) =>
                {
                    sentMessage = msg;
                    thrownException = ex;
                    waitHandle.Set();
                });

            EmailSender4 sut = new EmailSender4(mockCallback.Object);

            //Act
            sut.SendEmail(null);
            bool callbackCalled = waitHandle.Wait(2000);

            //Assert
            //Assert.That(callbackCalled, Is.True,  "OnFailure callback not called");
            //Assert.That(thrownException, Is.TypeOf<ArgumentNullException>(), "Invalid exception thrown");
            //Assert.That(((ArgumentNullException)thrownException).ParamName, Is.EqualTo("message"), "Invalid parameter name");
            //Assert.That(sentMessage, Is.Null,"OnFailure called with wrong message");

            Assert.Equal(callbackCalled, true);
        }
        
    }
    
}
