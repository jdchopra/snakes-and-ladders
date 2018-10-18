using System;

namespace SnakesAndLadders
{
    public class Die : IDie
    {
        public int Roll()
        {
            var randomNumberGen = new Random();
            return randomNumberGen.Next(1, 7);
        }
    }
}