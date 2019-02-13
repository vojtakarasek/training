using Vojta;
using Xunit;

namespace VojtaTest
{
    public class MatcherTest
    {
        [Theory]
        [InlineData("()",true)]
        [InlineData("((", false)]
        [InlineData(")(", false)]
        [InlineData("((()A))", true)]
        [InlineData("()()", true)]
        [InlineData("", true)]
        public void SimpleWorks(string expression, bool expected)
        {
            var m = new Matcher();
            Assert.Equal(expected, m.Simple(expression));
        }

        [Theory]
        [InlineData("()",true)]
        [InlineData("(]", false)]
        [InlineData(")(]", false)]
        [InlineData("([(([])A)])", true)]
        [InlineData("([)][(])", false)]
        [InlineData("[]", true)]
        public void ComplexWorks(string expression, bool expected)
        {
            var m = new Matcher();
            Assert.Equal(expected, m.Complex(expression));
        }
    }
}
