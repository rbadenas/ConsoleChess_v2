using ConsoleChess.pieces;
using System.Linq;

namespace ConsoleChess
{
    public class Player
    {
        private readonly Color color;
        private readonly Board board;
        private bool hasWon;

        public Player(Color color, Board board)
        {
            this.color = color;
            this.board = board;
            this.hasWon = false;
        }


        public void Play()
        {
            Square origin;
            Square destination;
            bool isLegalMovement;
            do
            {
                origin = ReadSquare("Origin square", true);
                destination = ReadSquare("Destination square", false);
                isLegalMovement = origin.GetPiece().IsLegalMovement(origin, destination);

                if (!isLegalMovement) { new ConsoleIO().Line("Not a valid movement\n\n"); }

            } while (!isLegalMovement);


            if (!destination.IsEmpty() && destination.GetPiece().GetType() == typeof(King))
            {
                this.hasWon = true;
            }

            this.Move(origin, destination);
        }

        public bool HasWon() => hasWon;

        private void Move(Square origin, Square destination)
        {
            destination.RemovePiece();
            destination.PutPiece(origin.GetPiece());
            origin.RemovePiece();
        }

        private Square ReadSquare(string promptText, bool isOrigin)
        {
            var console = new ConsoleIO();
            string input;
            Square square;
            bool isValid;

            do
            {
                input = console.InString(promptText + ": ");
                square = board.Squares().Where(x => x.FriendlyCoordinate() == input.ToUpper()).FirstOrDefault();

                isValid = square != null && square.IsValid() && (square.HasAllyPiece(color) == isOrigin);
                if (!isValid) { console.Line(promptText + " is not valid\n\n"); }

            } while (!isValid);

            return square;
        }

        public void CongratulateWinner()
        {
            new ConsoleIO().Line("Congratulations " + color.ToString() + " player!! You've WON!!!");
        }


        public override string ToString()
        {
            return color.ToString();
        }

    }
}