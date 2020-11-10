namespace ConsoleChess.pieces
{
    public abstract class Piece
    {
        protected Figure figure;
        protected Color color;

        protected Piece(Figure figure, Color color)
        {
            this.figure = figure;
            this.color = color;
        }

        public abstract bool CanMoveTo(Square origin, Square destination);

        public abstract char Symbol();

        public override string ToString()
        {
            var symbol = "" + Symbol();

            return Color.WHITE == color ? symbol : symbol.ToLower();
        }

        public Color GetColor() => color;

    }
}