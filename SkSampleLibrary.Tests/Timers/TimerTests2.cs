using System.Threading;
using Moq;
using Xunit;
using System;
using SkSampleLibrary.Timers;

namespace SkSampleLibrary.Tests.Timers
{
    public class TimerTests2
    {
        [Fact]
        public void Test_WithCallbackInterface()
        {
            //Arrange
            TimerUser2 sut = null;
            var waitHandle = new ManualResetEventSlim(false);
            int spinCount = 0;           

            var mockTimerCallback = new Mock<ITimerCallback>();
            mockTimerCallback.Setup(m => m.OnCallbackExecuted()).Callback(() =>
            {
                spinCount++;
                if (spinCount == 2)
                {
                    sut.Stop();
                    waitHandle.Set();
                }
            });

            sut = new TimerUser2(mockTimerCallback.Object);

            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");

            //Act
            sut.Start();
            waitHandle.Wait();

            //Assert
            //Assert.That(sut.MessageText, Is.EqualTo("AB"), "Message text is not correct");
            //Assert.That(sut.WaitingMessageCount, Is.EqualTo(2),  "Number of waiting messages is not correct");
            Assert.Equal(sut.MessageText, "AB");
            Assert.Equal(sut.WaitingMessageCount, 2);
        }
    }
}
