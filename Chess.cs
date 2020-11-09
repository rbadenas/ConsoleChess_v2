namespace ConsoleChess
{
    public class Chess
    {
        private readonly Board board;
        private readonly Turn turn;


        public Chess()
        {
            this.board = new Board();
            this.turn = new Turn(board);
        }

        public void Play()
        {
            do
            {
                board.Display();
                turn.Next();
                turn.CurrentPlayer().Play();
            } while (!turn.CurrentPlayer().HasWon());

            turn.CurrentPlayer().CongratulateWinner();
        }

    }
}
