using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Base class for goals
public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
}

class Program
{
    static List<Goal> _goals = new List<Goal>();
    static int _score = 0;

    static void Main(string[] args)
    {
        LoadGoals();

        while (true)
        {
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save and exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2 = 2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    SaveGoals();
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.Write("Choose a goal type: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string goalName = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = Convert.ToInt32(Console.ReadLine());

        Goal goal;
        switch (goalType)
        {
            case "1":
                goal = new SimpleGoal(goalName, points);
                break;
            case "2":
                goal = new EternalGoal(goalName, points);
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = Convert.ToInt32(Console.ReadLine());
                goal = new ChecklistGoal(goalName, points, targetCount, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal not created.");
                return;
        }

        _goals.Add(goal);
    }

    static void RecordEvent()
    {
        ShowGoals();
        Console.Write("Enter the number of the goal to record an event for: ");
        int goalIndex = Convert.ToInt32(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();
            _score += goal.Points;

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
            {
                _score += checklistGoal.BonusPoints;
            }

            Console.WriteLine($"Event recorded for {goal.Name}. You earned {goal.Points} points.");
            if (goal is ChecklistGoal checklistGoal2 && checklistGoal2.IsCompleted)
            {
                Console.WriteLine($"You completed the {checklistGoal2.Name} goal and earned a bonus of {checklistGoal2.BonusPoints} points!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    static void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name} - {_goals[i].GetStatus()}");
        }
    }

    static void ShowScore()
    {
        Console.WriteLine($"Your current score is: {_score}");
    }

    static void SaveGoals()
    {
        var goalsData = new GoalsData
        {
            Goals = _goals,
            Score = _score
        };

        string json = JsonSerializer.Serialize(goalsData);
        File.WriteAllText("goals.json", json);
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.json"))
        {
            string json = File.ReadAllText("goals.json");
            var goalsData = JsonSerializer.Deserialize<GoalsData>(json);
            _goals = goalsData.Goals;
            _score = goalsData.Score;
        }
    }
}

public class GoalsData
{
    public List<Goal> Goals { get; set; }
    public int Score { get; set; }
}