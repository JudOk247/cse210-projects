using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();

        // Validate the input
        if (int.TryParse(input, out int grade))
        {
            // Determine the letter grade
            string letter;
            if (grade >= 90)
            {
                letter = "A";
            }
            else if (grade >= 80)
            {
                letter = "B";
            }
            else if (grade >= 70)
            {
                letter = "C";
            }
            else if (grade >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            // Determine if the user passed the course
            if (grade >= 70)
            {
                Console.WriteLine($"You got a {letter}. Congratulations, you passed the course!");
            }
            else
            {
                Console.WriteLine($"You got a {letter}. Don't worry, you'll get 'em next time!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}