namespace ConsoleChess.pieces
{
    public class Queen : Piece
    {
        public Queen(Color color, Board board) : base(Figure.QUEEN, color, board)
        {

        }

        protected override bool CanMoveTo(Square origin, Square destination)
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

    }
}