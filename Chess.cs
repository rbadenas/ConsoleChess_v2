namespace ConsoleChess
{
    public class Chess
    {
        private readonly Board board;
        private readonly Turn turn;


        public Chess()
        {
            this.board = new Board();
            this.turn = new Turn();
        }

        public void Play()
        {
            do
            {
                board.Display();
                turn.Next();
                turn.Current().Play(board);
            } while (!turn.Current().HasWon());

            turn.CongratulateWinner();
        }

    }
}
