using System;

namespace SnakesAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            var die = new Die();
            var player = new Player(die);

            var game = new Game(player);
            Console.WriteLine("Press any key to roll the die.");
            while (game.Winner == null)
            {
                Console.WriteLine($"You are at square {player.Square}");
                Console.ReadKey();
                game.MakeMove();
            }

            Console.WriteLine("Congratulations. You are the winner.");
            Console.ReadLine();
        }
    }
}
