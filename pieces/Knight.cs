namespace ConsoleChess.pieces
{
    public class Knight : Piece
    {
        public Knight(Color color) : base(Figure.KNIGHT, color)
        {

        }

        public override bool CanMoveTo(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);

            if (Direction.KNIGHT_JUMP == direction
                && !destination.HasAllyPiece(color)) return true;

            return false;
        }

        public override char Symbol()
        {
            return 'N';
        }

    }
}