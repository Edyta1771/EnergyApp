namespace EnergyApp
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Sum { get; private set; }

        public Statistics()
        {
            this.Sum = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }

        public void AddDayUsage(float dayUsage)
        {
            this.Sum += dayUsage;
            this.Min = Math.Min(dayUsage, this.Min);
            this.Max = Math.Max(dayUsage, this.Max);
        }
    }
}
