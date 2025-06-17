public class ChecklistGoal : Goal
{
    public int RequiredCount { get; set; }
    public int CurrentCount { get; set; }

    public ChecklistGoal(string name, string description, int requiredCount) : base(name, description)
    {
        RequiredCount = requiredCount;
        CurrentCount = 0;
    }

    public void RecordEvent(int count)
    {
        CurrentCount += count;
        if (CurrentCount >= RequiredCount)
        {
            IsComplete = true;
        }
        Console.WriteLine($"Goal '{Name}' progress: {CurrentCount}/{RequiredCount}");
    }

    public override string GetDetailsString()
    {
        string status = IsComplete ? "Complete" : "Incomplete";
        return $"{Name} - {Description} - {CurrentCount}/{RequiredCount} - {status}";
    }
}

