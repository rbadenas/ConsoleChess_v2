using ConsoleChess.pieces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChess
{
    public class Board
    {
        public static readonly int SIZE = 8;
        private readonly List<Square> squares;

        public Board()
        {
            squares = new List<Square>();
            BuildSquares();
            PlacePieces();
        }

        public void Display()
        {
            var console = new ConsoleIO();

            console.Clear();
            console.Line("\n");
            for (int i = SIZE - 1; i >= 0; i--)
            {
                DisplayRowLabels(i + 1);
                for (int j = 0; j < SIZE; j++)
                {
                    GetSquare(SIZE * i + j).Display();
                }
                console.Line("");
            }

            DisplayColumnLabels();
        }

        public bool IsFreePathBetween(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);

            if (Direction.NONE == direction) return false;
            if (Direction.KNIGHT_JUMP == direction) return true;

            var distance = origin.DistanceWith(destination);
            var unitVector = origin.GetUnitVector(destination);
            var last = origin;

            for (int i = 1; i < distance; i++)
            {
                var square = last.Displaced(unitVector);

                if (!square.IsValid() || !this.GetSquare(square.GetIndex()).IsEmpty())
                {
                    return false;
                }
                last = square;
            }

            return true;
        }

        public Square SearchSquareByFriendyName(string name)
        {
            return squares.Where(x => x.GetName() == name.ToUpper()).FirstOrDefault();
        }

        private Square GetSquare(int index)
        {
            return squares[index];
        }

        private void BuildSquares()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    squares.Add(new Square(i, j));
                }
            }
        }

        private void PlacePieces()
        {
            for (int i = SIZE; i < SIZE + SIZE; i++)
            {
                this.GetSquare(i + 0 * SIZE).PutPiece(new Pawn(Color.WHITE));
                this.GetSquare(i + 5 * SIZE).PutPiece(new Pawn(Color.BLACK));
            }
            for (int i = 0; i < Enum.GetValues(typeof(Color)).Length; i++)
            {
                this.GetSquare(0 + i * 7 * SIZE).PutPiece(new Rook((Color)i));
                this.GetSquare(1 + i * 7 * SIZE).PutPiece(new Knight((Color)i));
                this.GetSquare(2 + i * 7 * SIZE).PutPiece(new Bishop((Color)i));
                this.GetSquare(3 + i * 7 * SIZE).PutPiece(new Queen((Color)i));
                this.GetSquare(4 + i * 7 * SIZE).PutPiece(new King((Color)i));
                this.GetSquare(5 + i * 7 * SIZE).PutPiece(new Bishop((Color)i));
                this.GetSquare(6 + i * 7 * SIZE).PutPiece(new Knight((Color)i));
                this.GetSquare(7 + i * 7 * SIZE).PutPiece(new Rook((Color)i));
            }
        }

        private void DisplayRowLabels(int row)
        {
            new ConsoleIO().Out("  " + row + " ");
        }

        private void DisplayColumnLabels()
        {
            string labelsLine = string.Empty;

            for (int i = 0; i < 8; i++)
            {
                labelsLine += (char)(65 + i) + "  ";
            }

            new ConsoleIO().Line("     " + labelsLine + "\n");
        }

    }
}