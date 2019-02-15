using Vojta;
using Xunit;

namespace VojtaTest
{
    public class StringToArrayTest
    {
        [Theory]
        [InlineData("", new int[0])]
        [InlineData("24", new[] { 2, 4 })]
        public void SimpleWorks(string expression, int[] expected)
        {
            var convertor = new StringToArray();
            Assert.Equal(expected, convertor.ConvertDigits(expression));
        }

        [Theory]
        [InlineData("", new int[0])]
        [InlineData("1,3,24", new[] { 1, 3, 24 })]
        public void ComplexWorks(string expression, int[] expected)
        {
            var convertor = new StringToArray();
            Assert.Equal(expected, convertor.Convert(expression));
        }

    }
}
