namespace Vojta
{
    public struct Position
    {
        public int Column;
        public int Row;
    }

    public class Board
    {
        bool[] _attackedColumns;
        bool[] _attackedRows;
        bool[] _attackedDiagU;
        bool[] _attackedDiagD;
        int _size;

        public Board(int size)
        {
            _size = size;
            _attackedColumns = new bool[size];
            _attackedRows = new bool[size];
            _attackedDiagD = new bool[2 * size - 1];
            _attackedDiagU = new bool[2 * size - 1];
        }

        public bool TryPlaceQueen(Position pos)
        {
            if (_attackedColumns[pos.Column]) return false;
            if (_attackedRows[pos.Row]) return false;
            if (_attackedDiagU[GetDiagU(pos)]) return false;
            if (_attackedDiagD[GetDiagD(pos)]) return false;

            _attackedColumns[pos.Column] = true;
            _attackedRows[pos.Row] = true;
            _attackedDiagU[GetDiagU(pos)] = true;
            _attackedDiagD[GetDiagD(pos)] = true;

            return true;
        }

        int GetDiagU(Position pos)
        {
            return pos.Column + (_size - pos.Row);
        }

        int GetDiagD(Position pos)
        {
            return pos.Column + pos.Row;
        }
    }



    public class QueenSolver
    {
        public QueenSolver(int boardSize)
        {
            
        }
    }
}
