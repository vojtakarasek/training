using Xunit;
using Vojta;

namespace VojtaTest
{
    public class PowTest
    {
        [Fact]
        public void BubbleSortWorks()
        {
            var pow = new Power();
            Assert.Equal(System.Math.Pow(8, 12), pow.Pow(8, 12));
        }
    }
}
