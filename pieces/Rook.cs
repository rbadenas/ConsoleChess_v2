namespace ConsoleChess.pieces
{
    public class Rook : Piece
    {
        public Rook(Color color, Board board) : base(Figure.ROOK, color, board)
        {

        }

        protected override bool CanMoveTo(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);

            if ((Direction.NORTH == direction 
                || Direction.SOUTH == direction
                || Direction.EAST == direction
                || Direction.WEST == direction)
                && !destination.HasAllyPiece(color)) return true;

            return false;
        }

    }
}