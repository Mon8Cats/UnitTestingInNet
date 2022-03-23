using Xunit;
using SkSampleLibrary.Fundamentals;

namespace SkSampleLibrary.Tests.Fundamentals
{
    public class HtmlFormatterTests
    {
        [Fact]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");
            
            // Specific 
            Assert.Equal(result.ToLower(), "<strong>abc</strong>");
            
            // More general
            Assert.StartsWith("<strong>", result.ToLower());
            Assert.EndsWith("</strong>", result.ToLower());
            Assert.Contains("abc", result.ToLower());
        }
        
    }
}