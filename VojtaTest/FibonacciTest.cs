using Vojta;
using Xunit;

namespace VojtaTest
{
    public class FibonacciTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(8, 21)]
        void FibTest(int n, int result)
        {
            var f = new Fibonacci();
            Assert.Equal(result, f.Fib(n));
        }

        [Fact]
        void FibArrayTest()
        {
            var n = 100;
            var fa = new Fibonacci().FibArray(n);
            Assert.Equal(0, fa[0]);
            Assert.Equal(1, fa[1]);
            //[0, 1, 1, 2, 3, 5, 8.
            for (var i = 2; i < n; i++)
                Assert.Equal(fa[i - 1] + fa[i - 2], fa[i]);

        }
    }
}