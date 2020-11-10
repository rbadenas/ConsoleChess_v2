namespace ConsoleChess.pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color) : base(Figure.BISHOP, color)
        {

        }

        public override bool CanMoveTo(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);

            if ((Direction.NORTHEAST == direction
                || Direction.NORTHWEST == direction
                || Direction.SOUTHEAST == direction
                || Direction.SOUTHWEST == direction)
                && !destination.HasAllyPiece(color)) return true;

            return false;
        }

        public override char Symbol()
        {
            return 'B';
        }
    }
}