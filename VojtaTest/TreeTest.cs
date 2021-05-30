using Vojta;
using Xunit;

namespace VojtaTest
{
    public class TreeTest
    {
        [Fact]
        void TreeIteration()
        {
            var tree = new Tree(5,
                left: new Tree(2, left: new Tree(1)),
                right: new Tree(7, left: new Tree(6), right: new Tree(8)));

            var list = tree.Iterate("", (acc, value) =>
                {
                    if (acc == "") return value.ToString();
                    return acc + ", " + value.ToString();
                });

            Assert.Equal("1, 2, 5, 6, 7, 8", list);
        }
    }
}
