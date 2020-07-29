using System;
using System.Collections.Generic;

namespace casino
{
    class Game
    {
        string userName;
        string stake;
        int dealer;
        int player;
        int balance;
        int maxAmountOfBet = 500;
        int blackjackHighestNumber = 21;

        public void initialise()
        {
            Console.WriteLine("Welcome to BlackJack!");
            Console.ReadKey();
            Console.Write("Enter player name: ");
            userName = Console.ReadLine();
            Console.WriteLine("Welcome {0}, lets start the game", userName);
            Console.ReadKey();
            startGame();
        }

        public void startGame()
        {
            betFunc();
            dealer = 0;
            player = 0;
            Console.WriteLine("{0} it's your turn", userName);
            Console.ReadKey();
            playerTurn();
            choice();
        }
        public void betFunc()
        {
            string stakeChosen;
            Console.Write("Time to place bets, how much would you like to stake? £");
            stakeChosen = Console.ReadLine();

            if (Convert.ToInt32(stakeChosen) < maxAmountOfBet)
            {
                stake = stakeChosen;
            }
            else
            {
                Console.WriteLine("Sorry that stake is too high for a single bet, please bet a smaller amount");
                betFunc();
            }
            Console.ReadKey();
        }
        public void playerTurn()
        {
            Random rnd = new Random();
            int[] blackJackNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            int playerIndex = rnd.Next(blackJackNumbers.Length);
            player += blackJackNumbers[playerIndex];

            Console.WriteLine("Your card is {0}", blackJackNumbers[playerIndex]);
        }
        public void choice()
        {
            string userInput;

            Console.WriteLine("Would you like to 1 - stick or 2 - twist?");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    stick();
                    break;
                case "2":
                    twist();
                    break;
                default:
                    Console.WriteLine("That is not a valid option, please try again");
                    choice();
                    break;
            }
        }

        public void stick()
        {
            if (player > blackjackHighestNumber)
            {
                Console.WriteLine("You have bust!");
                lose();
            }
            else
            {
                dealerTurn();
                Console.WriteLine("Your current score is {0}, you have chosen to stick, lets see who's won", player);

                if (dealer > player)
                {
                    lose();
                }
                else if (dealer < player)
                {
                    win();
                }
                else
                {
                    draw();
                }
            }
        }
        public void dealerTurn()
        {
            Random rnd = new Random();
            int[] blackJackNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            int dealerIndex = rnd.Next(blackJackNumbers.Length);
            dealer += blackJackNumbers[dealerIndex];

            if (dealer < 17)
            {
                dealerTurn();
            }
            else if (dealer > blackjackHighestNumber)
            {
                Console.WriteLine("Dealer has bust");
                win();
            }
            else
            {
                Console.WriteLine("Dealer has scored {0}", dealer);
            }
        }
        public void twist()
        {
            string userInput;
            playerTurn();
            if (player > blackjackHighestNumber)
            {
                Console.WriteLine("You have bust!");
                lose();
            }
            else
            {
                Console.WriteLine("Your current score is {0}, would you like to 1 - stick or 2 - twist?", player);
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    stick();
                }
                else if (userInput == "2")
                {
                    twist();
                }
            }
        }
        public void win()
        {
            string userInput;
            int times = 2;

            Console.WriteLine("Congrats {0}, you won that round!", userName);

            times *= Convert.ToInt32(stake);

            string winnings = Convert.ToString(times);

            Console.WriteLine("You have doubled your stake, you won: £{0}", winnings);
            Console.ReadKey();
            balance += Convert.ToInt32(winnings);
            Console.WriteLine("Your current balance is: {0}", balance);

            Console.WriteLine("Would you like to play again? Y or N");
            userInput = Console.ReadLine();

            if (userInput == "y" || userInput == "Y")
            {
                startGame();
            }
            else
            {
                endGame();
            }
        }
        public void lose()
        {
            string userInput;

            Console.WriteLine("Sorry {0}, you have lost! Would you like to play again? Y or N", userName);
            userInput = Console.ReadLine();

            if (userInput == "y" || userInput == "Y")
            {
                startGame();
            }
            else
            {
                endGame();
            }
        }
        public void draw()
        {
            string userInput;

            Console.WriteLine("{0}, you have drawn with the dealer! Would you like to play BlackJack again? Y or N", userName);
            userInput = Console.ReadLine();

            if (userInput == "y" || userInput == "Y")
            {
                startGame();
            }
            else
            {
                endGame();
            }
        }
        public void endGame()
        {
            Console.WriteLine("Thanks for playing, come back soon!");
        }

    }
}