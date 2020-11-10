namespace ConsoleChess
{
    public class Turn
    {
        private readonly Player[] players;
        private int currentPlayerIndex;

        public Turn()
        {
            this.players = new Player[] { new Player(Color.WHITE), new Player(Color.BLACK) };
            this.currentPlayerIndex = 1;
        }

        public void Next()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % 2;
            this.Display();
        }

        public Player Current()
        {
            return players[currentPlayerIndex];
        }

        public void Display()
        {
            new ConsoleIO().Line(Current().ToString() + " moves!\n");
        }

        public void CongratulateWinner()
        {
            new ConsoleIO().Line("Congratulations " + Current().GetColor().ToString() + " player!! You've WON!!!");
        }

    }
}