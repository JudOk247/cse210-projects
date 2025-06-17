public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description) : base(name, description)
    {
    }
}

// // Simple goal class
// public class SimpleGoal : Goal
// {
//     public SimpleGoal(string name, int points) : base(name, points) { }

//     public override void RecordEvent()
//     {
//         if (!IsCompleted)
//         {
//             IsCompleted = true;
//         }
//     }

//     public override string GetStatus()
//     {
//         return IsCompleted ? "[X]" : "[ ]";
//     }
// }