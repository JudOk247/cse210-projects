using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentage = Console.ReadLine();
        // string grade = gradePercentage.ToString();
        int percent = int.Parse(gradePercentage);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        {
            Console.WriteLine($"Your grae is {letter}");
        }
    }
}