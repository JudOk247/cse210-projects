public class EternalGoal : Goal
{
    public EternalGoal(string name, string description) : base(name, description)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for eternal goal '{Name}'.");
    }
}
    


