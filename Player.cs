namespace ConsoleChess
{
    public class Player
    {
        private readonly Color color;
        private bool hasWon;

        public Player(Color color)
        {
            this.color = color;
            this.hasWon = false;
        }

        public void Play(Board board)
        {
            Movement movement;

            do
            {
                var origin = ReadSquare("Origin square", board);
                var destination = ReadSquare("Destination square", board);
                var freePath = board.IsFreePathBetween(origin, destination);

                movement = new Movement(origin, destination, freePath);
                movement.Display();

            } while (!movement.IsLegal());

            this.hasWon = movement.WillCheckMate();

            movement.Execute();
        }

        public override string ToString()
        {
            return color.ToString();
        }

        public bool HasWon() => hasWon;

        public Color GetColor() => color;

        private Square ReadSquare(string promptText, Board board)
        {
            var console = new ConsoleIO();
            string input;
            Square square;

            do
            {
                input = console.InString(promptText + ": ");
                square = board.SearchSquareByFriendyName(input);
            } while (square == null || !square.IsValid());

            return square;
        }

    }
}