namespace ConsoleChess
{
    public class Turn
    {
        private readonly Player[] players;
        private int currentPlayerIndex;

        public Turn(Board board)
        {
            this.players = new Player[] { new Player(Color.WHITE, board), new Player(Color.BLACK, board) };
            this.currentPlayerIndex = 1;
        }

        public void Next()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % 2;
            this.Display();
        }

        public Player CurrentPlayer()
        {
            return players[currentPlayerIndex];
        }

        public void Display()
        {
            new ConsoleIO().Line(CurrentPlayer().ToString() + " moves!\n");
        }

    }
}