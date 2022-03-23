using Moq;
using Xunit;
using System;
using SkSampleLibrary.Timers;

namespace SkSampleLibrary.Tests.Timers
{
    public class TimerTests4
    {
        [Fact]
        public void Test_WithAbstractTimer()
        {
            //Arrange
            var mockTimer = new Mock<ITimer>();
            mockTimer.Setup(m => m.Start(It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            mockTimer.Setup(m => m.Stop()).Verifiable();

            var sut = new TimerUser4(mockTimer.Object);

            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");

            //Act
            sut.Start();
            //Raise the Tick event of the mock/fake timer
            mockTimer.Raise(m => m.Tick += null, "");
            mockTimer.Raise(m => m.Tick += null, "");
            sut.Stop();

            //Assert
            //mockTimer.Verify(m => m.Start(It.IsAny<int>(), It.IsAny<int>()), Times.Once(),  "Timer Start verification failed");
            //mockTimer.Verify(m => m.Stop(), Times.Once(), "Timer Stop verification failed");

            //Assert.That(sut.MessageText, Is.EqualTo("AB"), "Message text is not correct");
            //Assert.That(sut.WaitingMessageCount, Is.EqualTo(2),  "Number of waiting messages is not correct");

            mockTimer.Verify(m => m.Start(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
            mockTimer.Verify(m => m.Stop(), Times.Once());

            Assert.Equal(sut.MessageText, "AB");
            Assert.Equal(sut.WaitingMessageCount, 2);
        }
    }
}
