using System;

class Program
{
    static void Main()
    {
        bool playAgain = true;
        while (playAgain)
        {
            PlayGame();
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";
        }
    }

    static void PlayGame()
    {
        // Generate a random magic number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        int guessCount = 0;

        Console.WriteLine("Welcome to the Guess My Number game!");

        // Loop until the user guesses the magic number
        while (true)
        {
            // Ask the user for their guess
            Console.Write("What is your guess? ");
            if (int.TryParse(Console.ReadLine(), out int guess))
            {
                guessCount++;

                // Check if the guess is higher or lower than the magic number
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
                    Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}