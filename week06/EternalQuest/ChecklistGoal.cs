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


// // Checklist goal class
// public class ChecklistGoal : Goal
// {
//     public int TargetCount { get; set; }
//     public int CurrentCount { get; set; }
//     public int BonusPoints { get; set; }

//     public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
//     {
//         TargetCount = targetCount;
//         BonusPoints = bonusPoints;
//         CurrentCount = 0;
//     }

//     public override void RecordEvent()
//     {
//         CurrentCount++;
//         if (CurrentCount >= TargetCount)
//         {
//             IsCompleted = true;
//         }
//     }

//     public override string GetStatus()
//     {
//         return $"Completed {CurrentCount}/{TargetCount} times";
//     }
// }