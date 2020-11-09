using ConsoleChess.pieces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleChess
{
    public class Square
    {
        public static readonly Interval LIMITS = new Interval(0, Board.SIZE - 1);

        private readonly int row;
        private readonly int column;
        private readonly int index;
        private readonly string name;

        private Piece piece;


        public Square(int row, int column)
        {
            this.row = row;
            this.column = column;
            this.piece = null;
            this.index = Board.SIZE * row + column;
            this.name = "" + ((char)(column + 65)) + (row + 1);
        }


        public int Row() => this.row;
        public int Column() => this.column;
        public int GetIndex() => this.index;
        public Piece GetPiece() => this.piece;
        



        
        public Direction GetDirectionWith(Square other)
        {
            Debug.Assert(other != null);
            if (IsAtSameColumn(other) && IsMinorRow(other)) return Direction.NORTH;
            if (IsAtSameColumn(other) && !IsMinorRow(other)) return Direction.SOUTH;

            if (IsAtSameRow(other) && IsMinorColumn(other)) return Direction.EAST;
            if (IsAtSameRow(other) && !IsMinorColumn(other)) return Direction.WEST;

            if (IsAtSameDiagonal(other) && IsMinorRow(other)) return Direction.NORTHEAST;
            if (IsAtSameDiagonal(other) && !IsMinorRow(other)) return Direction.SOUTHEAST;

            if (IsAtSameReverseDiagonal(other) && IsMinorRow(other)) return Direction.NORTHWEST;
            if (IsAtSameReverseDiagonal(other) && !IsMinorRow(other)) return Direction.SOUTHWEST;

            if (IsAtHorseJump(other)) return Direction.KNIGHT_JUMP;

            return Direction.NONE;
        }

        public int RowDistance(Square other)
        {
            return other.row - this.row;
        }

        public int ColumnDistance(Square other)
        {
            return other.column - this.column;
        }

        public int MaxDistanceWith(Square other)
        {
            return Math.Max(Math.Abs(RowDistance(other)), Math.Abs(ColumnDistance(other)));
        }


        public void Display()
        {
            var console = new ConsoleIO();

            if (piece != null)
                console.Out("[" + piece.ToString() + "]");
            else
                console.Out("[ ]");
        }


        public override string ToString()
        {
            if (piece != null)
                return "[" + piece.ToString() + "]";

            return "[ ]";
        }

        public void DisplayFriendlyCoordinate()
        {
            new ConsoleIO().Out(FriendlyCoordinate() + " ");
        }

        public string FriendlyCoordinate()
        {
            return "" + ((char)(column + 65)) + (row + 1);
        }

        public Square GetUnitVector(Square other)
        {

            var direction = this.GetDirectionWith(other);

            int row = 0;
            int col = 0;

            if (direction == Direction.NORTH || direction == Direction.NORTHEAST || direction == Direction.NORTHWEST) { row++; }
            if (direction == Direction.SOUTH || direction == Direction.SOUTHEAST || direction == Direction.SOUTHWEST) { row--; }

            if (direction == Direction.EAST || direction == Direction.NORTHEAST || direction == Direction.SOUTHEAST) { col++; }
            if (direction == Direction.WEST || direction == Direction.NORTHWEST || direction == Direction.SOUTHWEST) { col--; }

            return new Square(row, col);
        }

        public Square Displaced(Square displacement)
        {
            return new Square(this.row + displacement.row, this.column + displacement.column);
        }




        public bool Equals(Square other)
        {
            return this.row == other.row && this.column == other.column;
        }

        public void PutPiece(Piece piece)
        {
            this.piece = piece;
        }

        public void RemovePiece()
        {
            this.piece = null;
        }

        public bool IsEmpty()
        {
            return piece == null;
        }

        public bool HasAllyPiece(Color color)
        {
            return !IsEmpty() && piece.GetColor() == color;
        }

        public bool IsValid()
        {
            return LIMITS.Includes(row) && LIMITS.Includes(column);
        }

        #region PRIVATE


        private bool IsAtSameColumn(Square other)
        {
            return other.column == this.column;
        }
        private bool IsAtSameRow(Square other)
        {
            return other.row == this.row;
        }
        private bool IsAtSameDiagonal(Square other)
        {
            return Math.Abs(other.column - other.row) == Math.Abs(this.column - this.row);
        }
        private bool IsAtSameReverseDiagonal(Square other)
        {
            return (other.row + other.column) == (this.row + this.column);
        }
        private bool IsAtHorseJump(Square other)
        {
            var rowDistance = Math.Abs(RowDistance(other));
            var colDistance = Math.Abs(ColumnDistance(other));

            return rowDistance == 1 && colDistance == 2 || rowDistance == 2 && colDistance == 1;
        }

        private bool IsMinorRow(Square other)
        {
            return other.row > this.row;
        }
        private bool IsMinorColumn(Square other)
        {
            return other.column > this.column;
        }

        


        #endregion




    }
}
