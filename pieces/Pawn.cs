namespace ConsoleChess.pieces
{
    public class Pawn : Piece
    {
        public Pawn(Color color) : base(Figure.PAWN, color) { }

        public override bool CanMoveTo(Square origin, Square destination)
        {
            var direction = origin.GetDirectionWith(destination);
            var distance = origin.DistanceWith(destination);

            if (Color.WHITE == color)
            {
                if (IsWhiteEating(direction, distance, destination)) return true;
                if (IsWhiteAdvancing(direction, distance, origin, destination)) return true;
            }
            else
            {
                if (IsBlackEating(direction, distance, destination)) return true;
                if (IsBlackAdvancing(direction, distance, origin, destination)) return true;
            }

            return false;
        }

        public override char Symbol()
        {
            return 'P';
        }

        private bool IsWhiteEating(Direction direction, int distance, Square destination)
        {
            return (Direction.NORTHEAST == direction || Direction.NORTHWEST == direction)
                && !destination.IsEmpty() && !destination.HasAllyPiece(color)
                && distance == 1;
        }

        private bool IsWhiteAdvancing(Direction direction, int distance, Square origin, Square destination)
        {
            return Direction.NORTH == direction && destination.IsEmpty()
                && ((distance <= 2 && origin.Row() == 1)
                || distance == 1);
        }

        private bool IsBlackEating(Direction direction, int distance, Square destination)
        {
            return ((Direction.SOUTHEAST == direction || Direction.SOUTHWEST == direction)
                && !destination.IsEmpty() && !destination.HasAllyPiece(color)
                && distance == 1);
        }

        private bool IsBlackAdvancing(Direction direction, int distance, Square origin, Square destination)
        {
            return Direction.SOUTH == direction && destination.IsEmpty()
                && ((distance <= 2 && origin.Row() == 6)
                || distance == 1);
        }

    }

}
