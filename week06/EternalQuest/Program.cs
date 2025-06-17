using System.Text.Json;


public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, string description)
    {
        Name = name;
        Description = description;
        IsComplete = false;
    }

    public virtual void RecordEvent()
    {
        IsComplete = true;
        Console.WriteLine($"Goal '{Name}' marked as complete.");
    }

    public virtual string GetDetailsString()
    {
        string status = IsComplete ? "Complete" : "Incomplete";
        return $"{Name} - {Description} - {status}";
    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Choose a goal type: ");
        int option = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        switch (option)
        {
            case 1:
                goals.Add(new SimpleGoal(name, description));
                break;
            case 2:
                goals.Add(new EternalGoal(name, description));
                break;
            case 3:
                Console.Write("Enter required count: ");
                int requiredCount = Convert.ToInt32(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, requiredCount));
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    static void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
    }

    static void SaveGoals()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new GoalConverter());

        string json = JsonSerializer.Serialize(goals, options);

        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();

        File.WriteAllText(fileName, json);
    }

    static void LoadGoals()
    {
        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();

        string json = File.ReadAllText(fileName);

        var options = new JsonSerializerOptions();
        options.Converters.Add(new GoalConverter());

        goals = JsonSerializer.Deserialize<List<Goal>>(json, options);
    }

    static void RecordEvent()
    {
        ListGoals();

        Console.Write("Enter goal number: ");
        int goalNumber = Convert.ToInt32(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < goals.Count)
        {
            var goal = goals[goalNumber];

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.Write("Enter count: ");
                int count = Convert.ToInt32(Console.ReadLine());
                checklistGoal.RecordEvent(count);
            }
            else
            {
                goal.RecordEvent();
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }
}

