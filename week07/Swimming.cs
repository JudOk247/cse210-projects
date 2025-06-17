using System;

namespace ExcerciseTracking
{
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
}