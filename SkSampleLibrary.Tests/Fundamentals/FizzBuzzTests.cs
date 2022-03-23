using Xunit;
using SkSampleLibrary.Fundamentals;

namespace SkSampleLibrary.Tests.Fundamentals
{
    public class FizzBuzzTests
    {
        [Fact]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            
            Assert.Equal(result, "FizzBuzz");
        }
        
        [Fact]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);
            
            Assert.Equal(result, "Fizz");
        }
        
        [Fact]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);
            
            Assert.Equal(result, "Buzz");
        }
        
        [Fact]
        public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnTheSameNumber()
        {
            var result = FizzBuzz.GetOutput(1);
            
            Assert.Equal(result, "1");
        }
        
    }
}