using Xunit;
using System;
using SkSampleLibrary.Timers;

namespace SkSampleLibrary.Tests.Timers
{
    public class TimerTests3
    {
        [Fact]
        public void Test_WithHumbleObjectPattern()
        {
            //Arrange
            FunctionalityClass sut = new FunctionalityClass();            

            sut.Add("A");
            sut.Add("B");
            sut.Add("C");
            sut.Add("D");

            //Act
            sut.DoWork();
            sut.DoWork();

            //Assert
            //Assert.That(sut.MessageText, Is.EqualTo("AB"), "Message text is not correct");
            //Assert.That(sut.WaitingMessageCount, Is.EqualTo(2),  "Number of waiting messages is not correct");
            Assert.Equal(sut.MessageText, "AB");
            Assert.Equal(sut.WaitingMessageCount, 2);
        }
    }
}
