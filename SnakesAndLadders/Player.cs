namespace SnakesAndLadders
{
    public class Player
    {
        private readonly IDie _die;
        public int Square { get; private set; }

        public Player(IDie die)
        {
            _die = die;
            Square = 1;
        }

        public void Roll()
        {
            var positionBeforeRoll = Square;
            var numberRolled = _die.Roll();
            Square += numberRolled;
            if (Square > 100)
                Square = positionBeforeRoll;
        }
    }
}