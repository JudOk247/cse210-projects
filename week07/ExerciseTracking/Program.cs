using System;
using System.Collections.Generic;

public abstract class Activity
{
    public DateTime Date { get; set; }
    public int Minutes { get; set; }

    public Activity(DateTime date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string activityType = GetType().Name;
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{Date.ToString("dd MMM yyyy")} {activityType} ({Minutes} min) - Distance {distance:F2} miles, Speed {speed:F2} mph, Pace: {pace:F2} min per mile";
    }
}

public class Running : Activity
{
    public double DistanceMiles { get; set; }

    public Running(DateTime date, int minutes, double distanceMiles) : base(date, minutes)
    {
        DistanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return DistanceMiles;
    }

    public override double GetSpeed()
    {
        return (DistanceMiles / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / DistanceMiles;
    }
}

public class Cycling : Activity
{
    public double DistanceMiles { get; set; }

    public Cycling(DateTime date, int minutes, double distanceMiles) : base(date, minutes)
    {
        DistanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return DistanceMiles;
    }

    public override double GetSpeed()
    {
        return (DistanceMiles / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / DistanceMiles;
    }
}

public class Swimming : Activity
{
    public int Laps { get; set; }

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 30, 5.0),
            new Swimming(new DateTime(2022, 11, 3), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}