using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Vojta
{
    [DebuggerDisplay("[c: {Column}, r: {Row}]")]
    public struct Position
    {
        public Position(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public int Column;
        public int Row;
    }

    public class Board
    {
        bool[] _attackedColumns;
        bool[] _attackedRows;
        bool[] _attackedDiagU;
        bool[] _attackedDiagD;
        Stack<Position> Queens;

        public int Size { get; }

        public Board(int size)
        {
            Size = size;
            _attackedColumns = new bool[size];
            _attackedRows = new bool[size];
            _attackedDiagD = new bool[2 * size - 1];
            _attackedDiagU = new bool[2 * size - 1];

            Queens = new Stack<Position>();
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

            Queens.Push(pos);

            return true;
        }

        int GetDiagU(Position pos)
        {
            return pos.Column + (Size - 1 - pos.Row);
        }

        int GetDiagD(Position pos)
        {
            return pos.Column + pos.Row;
        }

        public Position PopQueen()
        {
            var pos = Queens.Peek();
            Queens.Pop();
            _attackedColumns[pos.Column] = false;
            _attackedRows[pos.Row] = false;
            _attackedDiagU[GetDiagU(pos)] = false;
            _attackedDiagD[GetDiagD(pos)] = false;
            return pos;
        }

        public override string ToString()
        {
            var queens = Queens.ToArray();
            var sb = new StringBuilder();
            for (var r = 0; r < Size; r++)
            {
                for (var c = 0; c < Size; c++)
                {
                    if (queens.Any(q => q.Column == c && q.Row == r))
                        sb.Append('*');
                    else
                        sb.Append(' ');
                }
                sb.Append('|');
                sb.AppendLine();
            }
            return sb.ToString();
        }

        internal bool IsEmpty() => Queens.Count == 0;

        internal bool IsSolved() => Queens.Count == Size;

        internal ICollection<Position> GetSolution() => Queens.ToArray();
    }



    public class QueenSolver
    {
        Board _board;

        public QueenSolver(int boardSize)
        {
            _board = new Board(boardSize);
        }

        public IEnumerable<ICollection<Position>> Solve()
        {
            var actual = new Position(0, 0);
            _board.TryPlaceQueen(actual);
            while (true)
            {
                if (!TryMove(ref actual))
                {
                    if (_board.IsEmpty())
                        yield break;
                    actual = _board.PopQueen();
                    continue;
                }
                if (_board.TryPlaceQueen(actual))
                {
                    if (_board.IsSolved())
                    {
                        System.Console.WriteLine(_board);
                        yield return _board.GetSolution();
                    }
                }
            }
        }

        bool TryMove(ref Position pos)
        {
            pos.Column++;
            if (pos.Column < _board.Size)
                return true;
            pos.Column = 0;
            pos.Row++;
            return pos.Row < _board.Size;
        }
    }
}
