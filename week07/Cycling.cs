using System;

namespace ExcerciseTracking
{
    public class Cycling : Activity
    {
        public double Distance { get; set; }

        public Cycling(DateTime date, int minutes, double distance) : base(date, minutes)
        {
            Distance = distance;
        }

        public override double GetDistance()
        {
            return Distance;
        }

        public override double GetSpeed()
        {
            return (Distance / Minutes) * 60;
        }

        public override double GetPace()
        {
            return Minutes / Distance;
        }
    }
}