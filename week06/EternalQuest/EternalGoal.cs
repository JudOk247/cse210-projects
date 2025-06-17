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
    


// // Eternal goal class
// public class EternalGoal : Goal
// {
//     public EternalGoal(string name, int points) : base(name, points) { }

//     public override void RecordEvent()
//     {
//         // No need to do anything here, points are awarded when recording the event
//     }

//     public override string GetStatus()
//     {
//         return "[ ]";
//     }
// }


 