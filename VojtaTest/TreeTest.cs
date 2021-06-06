using Vojta;
using Xunit;

namespace VojtaTest
{
    public class TreeTest
    {

        public class SumVisitor : ITreeVisitor
        {
            int _sum = 0;

            public int Result => _sum;

            public void Visit(int nodeValue)
            {
                _sum += nodeValue;
            }
        }


        [Fact]
        void TreeIteration()
        {
            var tree = new Tree(5,
                left: new Tree(2, left: new Tree(1)),
                right: new Tree(7, left: new Tree(6), right: new Tree(8)));

            var sumVisitor = new SumVisitor();
            tree.Iterate(sumVisitor);
            Assert.Equal(29, sumVisitor.Result);
        }

        [Fact]
        void TreeIteration2()
        {
            var tree = new Tree(5,
                left: new Tree(2, left: new Tree(1)),
                right: new Tree(7, left: new Tree(6), right: new Tree(8)));      

            var concatenateVisitor = new ConcatenateVisitor();
            tree.Iterate(concatenateVisitor);
            Assert.Equal("1, 2, 5, 6, 7, 8", concatenateVisitor.Result);

        }
    }

    internal class ConcatenateVisitor : ITreeVisitor
    {
        string _concatenate = "";

        public string Result => _concatenate;
        public void Visit(int nodeValue)
        {
            if (_concatenate == "")
                _concatenate += nodeValue.ToString();
            else
                _concatenate += ", " + nodeValue.ToString();
        }
    }
}
