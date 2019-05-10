using Vojta;
using Xunit;

namespace VojtaTest
{
    public class GraphTest
    {
        [Fact]
        public void CalculatesDistance()
        {
            var g = new Graph<string>();
            var praha = new Vertex<string>("Praha");
            var brno = new Vertex<string>("Brno");
            var bratislava = new Vertex<string>("Bratislava");
            var kosice = new Vertex<string>("Kosice");
            g.AddLinked(praha, brno, 100);
            g.AddLinked(brno, praha, 120);
            g.AddLinked(brno, bratislava, 50);
            g.AddLinked(bratislava, kosice, 200);
            g.AddLinked(brno, kosice, 150);

            Assert.Equal(250, DistanceCalculator.MinDistance(g, praha, kosice));
        }
    }
}