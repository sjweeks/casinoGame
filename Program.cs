using System;

namespace casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Puzzles! Whilst enjoying our casino we advise you to gamble responsibly!");
            Console.ReadKey();
            
            StartGame newGame = new StartGame();
            newGame.newGame();
        }
    }
}
