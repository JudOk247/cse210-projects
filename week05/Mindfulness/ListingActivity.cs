using System;

public class ListingActivity : Activity
{
    private string[] _prompts = new string[] { "Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?" };
    private Random _random = new Random();

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine(_prompts[_random.Next(_prompts.Length)]);
        Console.WriteLine("Get ready to start listing...");
        ShowAnimation(5);
        int count = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("Enter an item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items.");
        DisplayEndingMessage();
    }
}