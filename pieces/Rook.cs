namespace ConsoleChess.pieces
{
    public class Rook : Piece
    {
        public Rook(Color color) : base(Figure.ROOK, color)
        {

        }

        public override bool CanMoveTo(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);

            if ((Direction.NORTH == direction
                || Direction.SOUTH == direction
                || Direction.EAST == direction
                || Direction.WEST == direction)
                && !destination.HasAllyPiece(color)) return true;

            return false;
        }

        public override char Symbol()
        {
            return 'R';
        }

    }
}