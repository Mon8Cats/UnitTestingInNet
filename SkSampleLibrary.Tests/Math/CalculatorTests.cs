using Xunit;
using System;
using SkSampleLibrary.Math;

namespace SkSampleLibrary.Tests.Math;

public class CalculatorTests
{        [Fact]
        public void AddShouldAddTwoNumbers()
        {
            //Arrange
            Calculator sut = new Calculator();

            //Act
            int actual = sut.Add(10, 20);

            //Assert
            Assert.Equal(30, actual);
        }

        [Fact]
        public void DivideShouldThrowExceptionWhenDivisorIsZero()
        {
            //Arrange
            Calculator sut = new Calculator();

            //Act + Assert
            Assert.Throws<InvalidOperationException>(() => sut.Divide(6, 0));

            /*
            var ex = Assert.Throws<InvalidOperationException>(() => sut.Divide(6, 0));
            Assert.Equal("some message", ex);

            */
        }
}