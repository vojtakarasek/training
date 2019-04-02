using Vojta;
using Xunit;

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








    }
    


}
