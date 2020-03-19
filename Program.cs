using System;

namespace casino
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;

        START:
            Console.WriteLine("Welcome to Puzzles! Whilst enjoying our casino we advise you to gamble responsibly!");
            Console.ReadKey();
            Console.WriteLine("Which game would you like to try your hand at today? 1 - BlackJack or 2 - Roulette");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Game playGame = new Game();
                playGame.initialise();
            }
            else if (userInput == "2")
            {
                rouletteGame playGame = new rouletteGame();
                playGame.initialise();
            }
            else
            {
                Console.WriteLine("Sorry that was not a valid selection, please try again.");
                goto START;
            }
        }
    }
}
