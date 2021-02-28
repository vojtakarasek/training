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
        
        [Theory]
        [InlineData(0, 0, 1, 1)]
        [InlineData(1, 1, 1, 1)]
        [InlineData(4, 2, 6, 2)]
        [InlineData(44, 22, 11, 11)]
        [InlineData(120, 135, 240, 15)]
        [InlineData(120000000, 2, 9, 1)]
        void GcdThree(int x, int y, int z, int result)
        {
            var f = new GcdCalculator();
            Assert.Equal(result, f.Gcd(x, y, z));
        }

        [Fact]
        void ThrowsOnNegativeNumber()
        {
            var f = new GcdCalculator();
            Assert.Throws<System.IO.InvalidDataException>(() =>  f.Gcd(-1, 10));
        }
    }
}