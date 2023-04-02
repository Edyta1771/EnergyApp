namespace EnergyApp
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Sum { get; private set; }

        public int Count { get; private set; }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }

        public void AddDayUsage(float dayUsage)
        {
            this.Count++;
            this.Sum += dayUsage;
            this.Min = Math.Min(dayUsage, this.Min);
            this.Max = Math.Max(dayUsage, this.Max);
        }

        //public void AddDayUsage(List<float> dayUsageList)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
