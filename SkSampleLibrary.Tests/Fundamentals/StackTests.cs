using Xunit;
using SkSampleLibrary.Fundamentals;
using System;

namespace SkSampleLibrary.Tests.Fundamentals
{
    public class StackTests
    {
        [Fact]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            var stack = new Stack<string>();
            
            Assert.Throws<ArgumentNullException>(() => stack.Push(null));
        }
        
        [Fact]
        public void Push_ValidArg_AddTheObjectToTheStack()
        {
            var stack = new Stack<string>();
            
            stack.Push("a");
            
            Assert.Equal(stack.Count, 1);
        }
        
        [Fact]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();
            
            Assert.Equal(stack.Count, 0);
        }
        
        [Fact]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }
        
        [Fact]
        public void Pop_StackWithAFewObjects_ReturnObjectOnTheTop()
        {
            // Arrange 
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            var result = stack.Pop();
            
            // Assert
            Assert.Equal(result, "c");
        }

        [Fact]
        public void Pop_StackWithAFewObjects_RemoveObjectOnTheTop()
        {
            // Arrange 
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            stack.Pop();
            
            // Assert
            Assert.Equal(stack.Count, 2);
        }
        
        [Fact]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }
        
        [Fact]
        public void Peek_StackWithObjects_ReturnObjectOnTopOfTheStack()
        {
            // Arrange 
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            var result = stack.Peek();
            
            // Assert
            Assert.Equal(result, "c");
        }
        
        [Fact]
        public void Peek_StackWithObjects_DoesNotRemoveTheObjectOnTopOfTheStack()
        {
            // Arrange 
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            // Act
            stack.Peek();
            
            // Assert
            Assert.Equal(stack.Count, 3);
        }
    }
}