using System;
using Xunit;
using SkSampleLibrary.Fundamentals;

namespace SkSampleLibrary.Tests.Fundamentals
{
    public class ErrorLoggerTests
    {
        [Fact]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();
            
            logger.Log("a");
            Assert.Equal(logger.LastError, "a");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();
            
            Assert.Throws<ArgumentNullException>(() => logger.Log(error));
        }

        [Fact]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");
            
            Assert.NotEqual(id.ToString(), "a");

        }
        
    }
}