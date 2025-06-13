using System;

// Exceeding requirements
public class GratitudeActivity : Activity
{
    public GratitudeActivity() : base("Gratitude", "This activity will help you reflect on the things you are grateful for.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Think about the things you are grateful for...");
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("Enter something you are grateful for: ");
            Console.ReadLine();
            ShowSpinner(2);
        }
        DisplayEndingMessage();
    }
}