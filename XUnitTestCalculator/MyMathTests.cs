using Calculator;
using System;
using Xunit;

namespace XUnitTestCalculator
{
    public class MyMathTests
    {
        [Theory]
        [InlineData('+', 96857.0, 1.002)]
        [InlineData('+', 0.0, 0.0)]
        [InlineData('+', -66.9, 66.9)]
        [InlineData('+', -4, -4)]
        public void Sum(char op, double x, double y)
        {
            Assert.Equal(x + y, MyMath.Perform(op, x, y));
        }
        [Theory]
        [InlineData('-', 96857.0, 1.002)]
        [InlineData('-', 0.0, 0.0)]
        [InlineData('-', -66.9, 66.9)]
        [InlineData('-', 4, -4)]
        public void Sub(char op, double x, double y)
        {
            Assert.Equal(x - y, MyMath.Perform(op, x, y));
        }
        [Theory]
        [InlineData('*', 96857.0, 1.002)]
        [InlineData('*', 0.0, 0.0)]
        [InlineData('*', -66.9, 66.9)]
        [InlineData('*', -4, -4)]
        public void Mult(char op, double x, double y)
        {
            Assert.Equal(x * y, MyMath.Perform(op, x, y));
        }
        [Theory]
        [InlineData('/', 96857.0, 1.002)]
        [InlineData('/', -66.9, 66.9)]
        [InlineData('/', -4, -4)]
        public void Div(char op, double x, double y)
        {
            Assert.Equal(x / y, MyMath.Perform(op, x, y));
        }
        [Theory]
        [InlineData('/', 96857.0, 0.0)]
        [InlineData('/', 0.0, 0.0)]
        public void Exceptions(char op, double x, double y)
        {
            try
            {
                Assert.Equal(0, MyMath.Perform(op, x, y));
            }
            catch (Exception ex)
            {
                Assert.Equal(new DivideByZeroException().Message, ex.Message);
            }
        }
    }
}
