using System;

namespace casino
{
    class StartGame
    {
        public void newGame()
        {
            string userInput;

            Console.WriteLine("Which game would you like to try your hand at today? 1 - BlackJack or 2 - Roulette");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Game playGame = new Game();
                    playGame.initialise();
                    break;
                case "2":
                    RouletteGame playSecondGame = new RouletteGame();
                    playSecondGame.initialise();
                    break;
                default:
                    Console.WriteLine("Sorry that was not a valid selection, please try again.");
                    newGame();
                    break;
            }
        }
    }
}