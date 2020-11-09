namespace ConsoleChess.pieces
{
    class WhitePawn : Piece
    {

        public WhitePawn(Board board) : base(Figure.PAWN, Color.WHITE, board)
        {

        }

        protected override bool CanMoveTo(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);
            var distance = origin.MaxDistanceWith(destination);


            if ((Direction.NORTHEAST == direction || Direction.NORTHWEST == direction)
                && !destination.IsEmpty() && !destination.HasAllyPiece(color)
                && distance == 1) return true;

            if (Direction.NORTH == direction && destination.IsEmpty()
                && ((distance <= 2 && origin.Row() == 1)
                || distance == 1)) return true;

            return false;
        }

    }

}
