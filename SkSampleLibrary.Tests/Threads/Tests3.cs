using System;
using System.Threading;
using Xunit;
using SkSampleLibrary.Threads;

namespace SkSampleLibrary.Tests.Threads
{
    
    public class Tests3
    {
        [Fact]
        //[Timeout(2000)]
        public void Test_MessageSentRaisedWithCorrectMessage()
        {        
            //Arrange
            var waitHandle = new ManualResetEventSlim(false);
            EmailMessage message = new EmailMessage() { Message="Hello" };
            EmailMessage sentMessage = null;
            EmailSender3 sut = new EmailSender3();
            sut.MessageSent += (m) => 
            {
                sentMessage = m;
                waitHandle.Set();
            };
                
            //Act
            sut.SendEmail(message);
            bool eventTriggered = waitHandle.Wait(2000);

            //Assert
            //Assert.That(eventTriggered, Is.EqualTo(true), "MessageSent event not raised");
            //Assert.That(sentMessage, Is.EqualTo(message), "MessageSent raised with wrong message");
            Assert.Equal(eventTriggered, true);
        }

        [Fact]        
        public void Test_MessageFailedRaisedWhenMessageIsNull()
        {
            //Arrange
            var waitHandle = new ManualResetEventSlim(false);            
            EmailMessage sentMessage = null;
            Exception thrownException = null;
            EmailSender3 sut = new EmailSender3();
            sut.MessageFailed += (m, e) =>
            {
                sentMessage = m;
                thrownException = e;
                waitHandle.Set();
            };

            //Act
            sut.SendEmail(null);
            bool eventTriggered = waitHandle.Wait(2000);

            //Assert
            //Assert.That(eventTriggered, Is.True, "MessageFailed event not raised");
            //Assert.That(thrownException, Is.TypeOf<ArgumentNullException>(), "Invalid exception thrown");
            //Assert.That(((ArgumentNullException)thrownException).ParamName, Is.EqualTo("message"), "Invalid parameter name");
            //Assert.That(sentMessage, Is.Null, "MessageFailed raised with wrong message");

            Assert.Equal(eventTriggered, true);
        }
    }
    
}
