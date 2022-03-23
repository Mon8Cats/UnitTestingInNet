using System.Linq;
using Xunit;
using SkSampleLibrary.Fundamentals;

namespace SkSampleLibrary.Tests.Fundamentals
{

    public class MathTests
    {
        private SkMath _math; 
        
        // SetUp
        // TearDown

        public MathTests()
        {
             _math = new SkMath();
        }
        
        [Fact]
//        [Ignore("Because I wanted to!")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(1, 2);
            
            Assert.Equal(result, 3);
        }

        [Theory]
        [InlineData(2, 1, 2)]
        [InlineData(1, 2, 2)]
        [InlineData(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);
            
//            Assert.That(result, Is.Not.Empty);

//            Assert.That(result.Count(), Is.EqualTo(3));
            
//            Assert.That(result, Does.Contain(1));
//            Assert.That(result, Does.Contain(3));
//            Assert.That(result, Does.Contain(5));
            
            Assert.Equal(result, new [] {1, 3, 5});

//            Assert.That(result, Is.Ordered);
//            Assert.That(result, Is.Unique);

        }
    }
}