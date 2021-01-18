using DaysOfCode.ConditionalStatements;
using Xunit;

namespace AlgorithmsTests.ConditionalStatements
{
    public class ConditionalTest
    {
        [Fact]
        public void TestCase01()
        {
            string result = Conditional.OddOrEven(3);

            Assert.Equal("Weird", result);
        }

        [Fact]
        public void TestCase02()
        {
            string result = Conditional.OddOrEven(24);

            Assert.Equal("Not Weird", result);
        }
    }
}
