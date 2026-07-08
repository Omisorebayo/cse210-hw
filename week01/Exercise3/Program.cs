using System;

class Program
{
    static void Main(string[] args)
    {
        string keepGoing = "yes";
        Random randomGenerator = new Random();

        Console.WriteLine("Welcome to the Magic Number Guessing Game!");

        while (keepGoing == "yes")
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;


            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! The magic number was {magicNumber}.");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            keepGoing = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Thanks for playing!");
    }
}