using System;
using System.Collections.Generic;

namespace casino
{
    class RouletteGame
    {
        string userName;
        string stake;
        string colour;
        int number;
        bool numberCheck;
        int odds;
        int balance;
        int oneNumber = 35;
        int twoNumbers = 17;
        int threeNumbers = 11;
        int fourNumbers = 8;

        public void initialise()
        {
            balance = 0;
            Console.WriteLine("Welcome to Roulette!");
            Console.Write("Enter player name: ");
            userName = Console.ReadLine();
            Console.WriteLine("Welcome {0}, lets start the game", userName);
            Console.ReadKey();
            startGame();
        }
        public void startGame()
        {
            string userInput;

            Console.WriteLine("How would you like to bet? 1 - Numbers, 2 - Red/Black, 3 - Odd/Even");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    betFunc();
                    numberBet();
                    break;
                case "2":
                    betFunc();
                    colourBet();
                    break;
                case "3":
                    betFunc();
                    oddBet();
                    break;
                default:
                    Console.WriteLine("That is not a valid option, please try again");
                    startGame();
                    break;
            }
        }
        public void numberBet()
        {
            string userInput;

            List<String> numbersChosen = new List<String>();

            Console.WriteLine("How many numbers would you like to choose - 1, 2, 3 or 4? ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    odds = oneNumber;
                    Console.WriteLine("Please choose 1 number");
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    break;
                case "2":
                    odds = twoNumbers;
                    Console.WriteLine("Please choose 2 numbers");
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    break;
                case "3":
                    odds = threeNumbers;
                    Console.WriteLine("Please choose 3 numbers");
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    break;
                case "4":
                    odds = fourNumbers;
                    Console.WriteLine("Please choose 4 numbers");
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    userInput = Console.ReadLine();
                    numbersChosen.Add(userInput);
                    break;
                default:
                    Console.WriteLine("Sorry that's not a valid option. Please try again");
                    numberBet();
                    break;
            }

            Console.WriteLine("Your odds are: {0}/1", odds);
            Console.ReadKey();
            numberGenerator();

            if (numbersChosen.Contains(Convert.ToString(number)))
            {
                odds *= Convert.ToInt32(stake);
                string winnings = Convert.ToString(odds);
                Console.WriteLine("You won {0}", winnings);
                balance += Convert.ToInt32(stake);
                Console.WriteLine("Your balance is currently: {0}", balance);

                win();
            }
            else
            {
                lose();
            }
        }

        public void colourBet()
        {
            string userInput;

            Console.WriteLine("You have chosen to bet via colours. Would you like to choose: 1 - Red or 2 - Black");
            userInput = Console.ReadLine();
            Console.ReadKey();

            if (userInput == "1")
            {
                colourGenerator();
                if (colour == "Red")
                {
                    standardWin();
                }
                else
                {
                    lose();
                }
            }
            else if (userInput == "2")
            {
                colourGenerator();
                if (colour == "Black")
                {
                    standardWin();
                }
                else
                {
                    lose();
                }
            }
        }
        public void oddBet()
        {
            string userInput;

            Console.WriteLine("You have chosen to pick either Odd or Even. 1 - Odd or 2 - Even");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                evenGenerator();
                if (numberCheck == true)
                {
                    lose();
                }
                else
                {
                    standardWin();
                }
            }
            else if (userInput == "2")
            {
                evenGenerator();
                if (numberCheck == true)
                {
                    standardWin();
                }
                else
                {
                    lose();
                }
            }
        }
        public void betFunc()
        {
            string stakeChosen;
            Console.Write("Time to place bets, how much would you like to stake? £");
            stakeChosen = Console.ReadLine();

            if (Convert.ToInt32(stakeChosen) < 500)
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
        public void colourGenerator()
        {
            Random rnd = new Random();
            string[] colourPick = { "Red", "Black" };
            int playerIndex = rnd.Next(colourPick.Length);
            Console.WriteLine("The number landed on: {0}", colourPick[playerIndex]);
            colour = colourPick[playerIndex];
        }
        public void numberGenerator()
        {
            Random rndno = new Random();
            int randomGenerator = rndno.Next(0, 37);
            number = randomGenerator;
            Console.WriteLine(number);
        }
        public void evenGenerator()
        {
            numberGenerator();
            if (number % 2 == 0)
            {
                Console.WriteLine("The number rolled was Even");
                Console.ReadKey();
                numberCheck = true;
            }
            else
            {
                Console.WriteLine("The number rolled was Odd");
                Console.ReadKey();
                numberCheck = false;
            }
        }
        public void standardWin()
        {
            int times = 2;

            Console.WriteLine("Congrats {0}, you won that round!", userName);
            times *= Convert.ToInt32(stake);

            string winnings = Convert.ToString(times);

            Console.WriteLine("You have doubled your stake, you just won: £{0}", winnings);
            Console.ReadKey();
            balance += Convert.ToInt32(winnings);
            Console.WriteLine("Your current balance is: {0}", balance);

            win();
        }
        public void win()
        {
            string userInput;

            Console.WriteLine("Would you like to play again? Y or N");
            userInput = Console.ReadLine();

            if (userInput == "y")
            {
                startGame();
            }
            else if (userInput == "n")
            {
                endGame();
            }
        }
        public void lose()
        {
            string userInput;
            balance -= Convert.ToInt32(stake);
            Console.WriteLine("Sorry {0}, you have lost. Your new balance is: {1}", userName, balance);
            Console.ReadKey();
            Console.WriteLine("Would you like to play Roulette again? Y or N");
            userInput = Console.ReadLine();

            if (userInput == "y")
            {
                startGame();
            }
            else if (userInput == "n")
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