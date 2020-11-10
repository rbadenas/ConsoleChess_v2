using ConsoleChess.pieces;

namespace ConsoleChess
{
    public class Movement
    {
        private readonly Piece piece;
        private readonly Square origin;
        private readonly Square destination;
        private readonly bool freePath;
        private readonly bool isLegal;

        public Movement(Square origin, Square destination, bool freePath)
        {
            this.origin = origin;
            this.destination = destination;
            this.piece = origin.GetPiece();
            this.freePath = freePath;
            this.isLegal = SetIsLegalMovement();
        }

        public bool IsLegal() => isLegal;


        public bool WillCheckMate()
        {
            if (!destination.IsEmpty() && destination.GetPiece().GetType() == typeof(King))
                return true;

            return false;
        }

        public void Execute()
        {
            destination.RemovePiece();
            destination.PutPiece(piece);
            origin.RemovePiece();
        }

        public void Display()
        {
            if (!isLegal)
            {
                new ConsoleIO().Line("Not a valid movement\n\n");
            }
            else
            {
                new ConsoleIO().Line("Movement from " + origin.GetName() + " to " + destination.GetName() + "\n\n");
            }
        }

        private bool SetIsLegalMovement()
        {
            if (origin.IsEmpty()
                || !origin.HasAllyPiece(piece.GetColor())
                || destination.HasAllyPiece(piece.GetColor())
                ) return false;

            if (freePath && piece.CanMoveTo(origin, destination))
                return true;

            return false;
        }

    }
}
