using Vojta;
using Xunit;

namespace VojtaTest
{
    public class GcdTest
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(4, 2, 2)]
        [InlineData(44, 22, 22)]
        [InlineData(120, 135, 15)]
        [InlineData(120000000, 2, 2)]
        void Gcd(int x, int y, int result)
        {
            var f = new GcdCalculator();
            Assert.Equal(result, f.Gcd(x, y));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(4, 2, 2)]
        [InlineData(44, 22, 22)]
        [InlineData(120, 135, 15)]
        [InlineData(120000000, 2, 2)]
        void GcdFaster(int x, int y, int result)
        {
            var f = new GcdCalculator();
            Assert.Equal(result, f.GcdFaster(x, y));
        }
    }
}