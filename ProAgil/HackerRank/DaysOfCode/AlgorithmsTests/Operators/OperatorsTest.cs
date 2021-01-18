using Operators;
using Xunit;

namespace AlgorithmsTests.Operators
{
    public class OperatorsTest
    {
        [Fact]
        public void TestCase01()
        {
            double result = Operator.solve(12.00, 20, 8);
            Assert.Equal(15, result);
        }

        [Fact]
        public void TestCase02()
        {
            double result = Operator.solve(15.50, 15, 10);
            Assert.Equal(19, result);
        }

        [Fact]
        public void TestCase03()
        {
            double result = Operator.solve(10.25, 17, 5);
            Assert.Equal(13, result);
        }
    }
}
