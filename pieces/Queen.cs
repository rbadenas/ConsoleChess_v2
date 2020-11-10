namespace ConsoleChess.pieces
{
    public class Queen : Piece
    {
        public Queen(Color color) : base(Figure.QUEEN, color)
        {

        }

        public override bool CanMoveTo(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);

            if ((Direction.NORTH == direction
                || Direction.SOUTH == direction
                || Direction.EAST == direction
                || Direction.WEST == direction
                || Direction.NORTHEAST == direction
                || Direction.NORTHWEST == direction
                || Direction.SOUTHEAST == direction
                || Direction.SOUTHWEST == direction)
                && !destination.HasAllyPiece(color)) return true;

            return false;
        }

        public override char Symbol()
        {
            return 'Q';
        }

    }
}