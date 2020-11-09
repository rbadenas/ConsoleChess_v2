using ConsoleChess.pieces;
using System.Collections.Generic;

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

        public List<Square> Squares() => squares;

        public static List<string> GetAllSquareNames()
        {
            var result = new List<string>();

            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    result.Add("" + ((char)(j + 65)) + (i + 1));
                }
            }
            return result;
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
                    GetSquareByID(SIZE * i + j).Display();
                }
                console.Line("");
            }

            DisplayColumnLabels();
        }


        public Square GetSquareByID(int index)
        {
            return squares[index];
        }


        #region PRIVATE

        private void PlacePieces()
        {
            PlacePawns();
            PlaceRooks();
            PlaceKnights();
            PlaceBishops();
            PlaceRoyalty();
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
        private void PlacePawns()
        {
            for (int i = SIZE; i < SIZE + SIZE; i++)
            {
                this.GetSquareByID(i + 0 * SIZE).PutPiece(new WhitePawn(this));
                this.GetSquareByID(i + 5 * SIZE).PutPiece(new BlackPawn(this));
            }
        }
        private void PlaceRooks()
        {
            this.GetSquareByID(0).PutPiece(new Rook(Color.WHITE, this));
            this.GetSquareByID(7).PutPiece(new Rook(Color.WHITE, this));
            this.GetSquareByID(56).PutPiece(new Rook(Color.BLACK, this));
            this.GetSquareByID(63).PutPiece(new Rook(Color.BLACK, this));
        }
        private void PlaceKnights()
        {
            this.GetSquareByID(1).PutPiece(new Knight(Color.WHITE, this));
            this.GetSquareByID(6).PutPiece(new Knight(Color.WHITE, this));
            this.GetSquareByID(57).PutPiece(new Knight(Color.BLACK, this));
            this.GetSquareByID(62).PutPiece(new Knight(Color.BLACK, this));
        }
        private void PlaceBishops()
        {
            this.GetSquareByID(2).PutPiece(new Bishop(Color.WHITE, this));
            this.GetSquareByID(5).PutPiece(new Bishop(Color.WHITE, this));
            this.GetSquareByID(58).PutPiece(new Bishop(Color.BLACK, this));
            this.GetSquareByID(61).PutPiece(new Bishop(Color.BLACK, this));
        }
        private void PlaceRoyalty()
        {
            this.GetSquareByID(3).PutPiece(new Queen(Color.WHITE, this));
            this.GetSquareByID(4).PutPiece(new King(Color.WHITE, this));
            this.GetSquareByID(59).PutPiece(new Queen(Color.BLACK, this));
            this.GetSquareByID(60).PutPiece(new King(Color.BLACK, this));
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


        #endregion
    }
}

