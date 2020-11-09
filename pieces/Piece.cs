namespace ConsoleChess.pieces
{
    public abstract class Piece
    {
        protected Figure figure;
        protected Color color;
        protected Board board;

        protected Piece(Figure figure, Color color, Board board)
        {
            this.figure = figure;
            this.color = color;
            this.board = board;
        }


        protected abstract bool CanMoveTo(Square origin, Square destination);

        private bool IsFreeWayBetween(Square origin, Square destination)
        {

            var direction = origin.GetDirectionWith(destination);

            if (Direction.NONE == direction) return false;
            if (Direction.KNIGHT_JUMP == direction) return true;

            var distance = origin.MaxDistanceWith(destination);
            var unitVector = origin.GetUnitVector(destination);
            var last = origin;

            for (int i = 1; i < distance; i++)
            {
                var square = last.Displaced(unitVector);

                if (!square.IsValid() || !board.GetSquareByID(square.GetIndex()).IsEmpty())
                {
                    return false;
                }
                last = square;
            }

            return true;
        }

        public bool IsLegalMovement(Square origin, Square destination)
        {
            if (!origin.IsValid() || !destination.IsValid() || !origin.HasAllyPiece(color)) return false;

            if (IsFreeWayBetween(origin, destination) && CanMoveTo(origin, destination))
                return true;

            return false;
        }

        public override string ToString()
        {
            var result = "" + ((char)figure);

            if (this.color == Color.BLACK)
                return result.ToLower();

            return result;
        }

        public Color GetColor() => color;

    }
}