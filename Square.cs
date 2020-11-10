using ConsoleChess.pieces;

namespace ConsoleChess
{
    public class Square
    {
        private readonly Coordinate coordinte;
        private readonly int index;
        private readonly string name;
        private Piece piece;

        public Square(int row, int column)
        {
            this.coordinte = new Coordinate(column, row);

            this.piece = null;
            this.index = Board.SIZE * row + column;
            this.name = "" + ((char)(column + 65)) + (row + 1);
        }

        public void PutPiece(Piece piece)
        {
            this.piece = piece;
        }

        public void RemovePiece()
        {
            this.piece = null;
        }

        public void Display()
        {
            var console = new ConsoleIO();

            if (piece != null)
                console.Out("[" + piece.ToString() + "]");
            else
                console.Out("[ ]");
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
            return 0 <= this.Column() && this.Column() <= Board.SIZE - 1
                && 0 <= this.Row() && this.Row() <= Board.SIZE - 1;
        }

        public Direction GetDirectionWith(Square other)
        {
            return this.coordinte.GetDirectionWith(Square.ToCoordinate(other));
        }

        public Square GetUnitVector(Square other)
        {
            var coordinate = Square.ToCoordinate(other);
            return Coordinate.ToSquare(this.coordinte.GetUnitVector(coordinate));
        }

        public Square Displaced(Square displacement)
        {
            var coordDisplacement = Square.ToCoordinate(displacement);
            return Coordinate.ToSquare(this.coordinte.Displaced(coordDisplacement));
        }

        public int DistanceWith(Square other)
        {
            return this.coordinte.Distance(Square.ToCoordinate(other));
        }

        public int Row() => this.coordinte.GetY();

        public int Column() => this.coordinte.GetX();

        public int GetIndex() => this.index;

        public Piece GetPiece() => this.piece;

        public string GetName() => this.name;

        public static Coordinate ToCoordinate(Square square)
        {
            return new Coordinate(square.Column(), square.Row());

        }

    }
}
