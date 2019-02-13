using Vojta;
using Xunit;

namespace VojtaTest
{
    public class FactorialTest
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(5, 120)]
        void FactTest(int n, int result)
        {
            var f = new FactorialCalc();
            Assert.Equal(result, f.Factorial(n));
        }
    }
}