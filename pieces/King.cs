namespace ConsoleChess.pieces
{
    public class King : Piece
    {
        public King(Color color) : base(Figure.KING, color)
        {

        }

        public override bool CanMoveTo(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);
            var distance = origin.DistanceWith(destination);

            if ((Direction.NORTH == direction
                || Direction.SOUTH == direction
                || Direction.EAST == direction
                || Direction.WEST == direction
                || Direction.NORTHEAST == direction
                || Direction.NORTHWEST == direction
                || Direction.SOUTHEAST == direction
                || Direction.SOUTHWEST == direction)
                && !destination.HasAllyPiece(color)
                && distance == 1) return true;

            return false;
        }

        public override char Symbol()
        {
            return 'K';
        }

    }
}