namespace SnakesAndLadders
{
    public class Game
    {
        public Player Winner { get; private set; }
        private readonly Player _player;

        public Game(Player player)
        {
            _player = player;
        }

        public void MakeMove()
        {
            _player.Roll();
            
            if (_player.Square == 100)
                Winner = _player;
        }
    }
}
