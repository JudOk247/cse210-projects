using System;
using System.Collections.Generic;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine(_description);
        Console.Write("How long would you like to participate in this activity? ");
        _duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowAnimation(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("You have done a good job!");
        ShowAnimation(3);
        Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
        ShowAnimation(5);
    }

    protected void ShowAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} ");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = new string[] { "-", "\\", "|", "/" };
        int index = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write($"\r{spinner[index]} ");
            index = (index + 1) % 4;
            System.Threading.Thread.Sleep(250);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}


class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    GratitudeActivity gratitudeActivity = new GratitudeActivity();
                    gratitudeActivity.Run();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid activity.");
                    break;
            }
        }
    }
}