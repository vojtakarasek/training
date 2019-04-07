using System.Linq;
using Vojta;
using Xunit;
using Xunit.Abstractions;

namespace VojtaTest
{
    public class QueensTest
    {
        [Fact]
        public void BoardChecksPosition()
        {
            var board = new Board(4);
            var corner = new Position { Column = 0, Row = 0 };
            Assert.True(board.TryPlaceQueen(corner));
            Assert.False(board.TryPlaceQueen(new Position { Column = 1, Row = 0 }));
            Assert.False(board.TryPlaceQueen(new Position { Column = 1, Row = 1 }));
            Assert.False(board.TryPlaceQueen(new Position { Column = 0, Row = 1 }));
            Assert.False(board.TryPlaceQueen(new Position { Column = 3, Row = 3 }));
            Assert.True(board.TryPlaceQueen(new Position { Column = 1, Row = 2 }));
            Assert.True(board.TryPlaceQueen(new Position { Column = 3, Row = 1 }));
        }

        [Fact]
        public void SolverFindsSolutions()
        {
            var solver = new QueenSolver(4);
            int count = 0;
            foreach (var solution in solver.Solve())
            {
                count++;

                Assert.Equal(4, solution.Count);
                var board = new Board(4);
                foreach (var pos in solution)
                    Assert.True(board.TryPlaceQueen(pos));
            }
            Assert.Equal(2, count);
        }

        [Fact]
        public void SolverFinds92Solutions()
        {
            var solver = new QueenSolver(8);
            Assert.Equal(92, solver.Solve().Count());
        }
    }
}
