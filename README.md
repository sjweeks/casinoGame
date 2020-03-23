# Casino Project

This project is fully using C#. It's a console based Casino, with both BlackJack and Roulette games

## How to initialise
- Download - https://dotnet.microsoft.com/download
- If using VS Code, download the C# extensions 

## Areas of improvements
This is the initial game so it is a very basic version of both games so there are additions that can be added
    - Implementing the full rules of BlackJack, including things such as Pair Splitting etc. 
    - Implementing best practices across both of the games

## Initial walkthrough
- dotnet run to start the game. 
- The user will then be asked which game they would like to play, Roulette or BlackJack

## BlackJack Walkthrough
- Initially the game will welcome you and ask you to input your name
- Then the user will be asked to input the stake they would like to bet
- The game will then randomly generate a card number and assign it to the users hand
- The user is then promtped to decide whether to stick or twist
    - If the user twists then they will be assigned another random card number and asked the question again. If the user twists and ends up with a hand greater than 21 then they will go bust and automcatically lose
    - If the user decides to stick then the dealer will then have a turn, the dealer is assigned a card initially. If less than 17 they will be given another card number, if the dealer goes 21 or above then they will bust, if the number is between 17 - 21 then they automatically stick and then the game will check whether the dealer or player has won
- If the player wins then the stake they inputted at the beginning will be doubled.
- The player will be asked if they'd like to play again. If they do then they will be sent back to inputting a stake amount.


## Roulette Walkthrough
- Initially the game will welcome you and ask you to input your name
- Then the user will be asked whether they would like to make a bet on Numbers, Red/Black or Odd/Even
- If the user picks Numbers:
    - The user will be asked how much they are betting
    - They will be asked how many numbers they would like to bet on between 1-4. Odds are different depending on how many numbers they choose - 1 numbers 35/1, 2 numbers 17/1, 3 numbers 11/1 and 4 numbers 8/1. Once they have inputted their numbers the console will generate a random number, if the number matches what they have chosen then they will have won. The console then calculates their win dependant on the odds. 
- If the user picks Red/Black:
    - The user will be asked how much they are betting
    - They then choose if they are betting on Red or Black
    - The console then randomly generates either Red or Black
    - If the user picked correctly then their stake is doubled
- If the user picks Odd/Even:
    - The user will be asked how much they are betting
    - They then choose if they are betting on Odd or Even
    - The console then randomly generates a number
    - If the user picked correctly then their stake is doubled
