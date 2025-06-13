using System;
using System.Collections.Generic;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowAnimation(4);
            if ((DateTime.Now - startTime).TotalSeconds >= _duration) break;
            Console.WriteLine("Breathe out...");
            ShowAnimation(4);
        }
        DisplayEndingMessage();
    }
}