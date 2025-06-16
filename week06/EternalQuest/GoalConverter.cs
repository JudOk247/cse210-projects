using System.Text.Json;
using System.Text.Json.Serialization;

public class GoalConverter : JsonConverter<Goal>
{
    public override Goal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);
        JsonElement root = doc.RootElement;

        string name = root.GetProperty("Name").GetString();
        int points = root.GetProperty("Points").GetInt32();
        bool isCompleted = root.GetProperty("IsCompleted").GetBoolean();

        Goal goal;

        if (root.TryGetProperty("TargetCount", out JsonElement targetCountElement))
        {
            int targetCount = targetCountElement.GetInt32();
            int bonusPoints = root.GetProperty("BonusPoints").GetInt32();
            int currentCount = root.GetProperty("CurrentCount").GetInt32();

            goal = new ChecklistGoal(name, points, targetCount, bonusPoints);
            ((ChecklistGoal)goal).CurrentCount = currentCount;
        }
        else if (root.GetProperty("Name").GetString().Contains("Simple"))
        {
            goal = new SimpleGoal(name, points);
        }
        else
        {
            goal = new EternalGoal(name, points);
        }

        goal.IsCompleted = isCompleted;

        return goal;
    }

    public override void Write(Utf8JsonWriter writer, Goal value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("Name", value.Name);
        writer.WriteNumber("Points", value.Points);
        writer.WriteBoolean("IsCompleted", value.IsCompleted);

        if (value is ChecklistGoal checklistGoal)
        {
            writer.WriteNumber("TargetCount", checklistGoal.TargetCount);
            writer.WriteNumber("CurrentCount", checklistGoal.CurrentCount);
            writer.WriteNumber("BonusPoints", checklistGoal.BonusPoints);
        }

        writer.WriteEndObject();
    }
}