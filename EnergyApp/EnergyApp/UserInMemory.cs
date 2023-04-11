namespace EnergyApp
{
    public class UserInMemory : UserBase
    {
        public override event UsageAddedDelegate UsageAdded;

        public override event DaysAddedDelegate DaysAdded;

        public float UsageListSum { get; private set; }

        public float DaysListSum { get; private set; }

        public float AverageDailyUsage { get; private set; }

        public int MinDayUsageInvoiceNumber { get; private set; }

        public int MaxDayUsageInvoiceNumber { get; private set; }

        public List<float> UsageList { get; private set; } = new List<float>();

        public List<float> DaysList { get; private set; } = new List<float>();

        public List<float> DayUsageList { get; private set; } = new List<float>();

        public UserInMemory(string userId)
            : base(userId)
        {
            this.UsageListSum = 0;
            this.DaysListSum = 0;
            this.MinDayUsageInvoiceNumber = 0;
            this.MaxDayUsageInvoiceNumber = 0;
        }

        public override void AddUsage(float usage)
        {
            if (usage >= 0)
            {
                this.UsageList.Add(usage);

                if (UsageAdded != null)
                {
                    UsageAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid usage value");
            }
        }

        public override void AddUsage(string usage)
        {
            if (float.TryParse(usage, out float result))
            {
                this.AddUsage(result);
            }
            else
            {
                throw new Exception("Invalid usage value, please try again");
            }
        }

        public override void AddUsage(double usage)
        {
            float doubleAsFloat = (float)usage;
            this.AddUsage(doubleAsFloat);
        }

        public override void AddUsage(int usage)
        {
            float intAsFloat = usage;
            this.AddUsage(intAsFloat);
        }

        public override void AddDays(float days)
        {
            if (days >= 0)
            {
                this.DaysList.Add(days);

                if (DaysAdded != null)
                {
                    DaysAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid days value");
            }
        }

        public override void AddDays(string days)
        {
            if (float.TryParse(days, out float result))
            {
                this.AddDays(result);
            }
            else
            {
                throw new Exception("Invalid days value, please try again");
            }
        }

        public override void AddDays(int days)
        {
            float intAsFloat = days;
            this.AddDays(intAsFloat);
        }

        public override void AddDays(double days)
        {
            float doubleAsFloat = (float)days;
            this.AddDays(doubleAsFloat);
        }

        public override void AddDayUsage()
        {
            for (int i = 0; i < UsageList.Count; i++)
            {
                var dayUsage = this.UsageList[i] / this.DaysList[i];
                this.DayUsageList.Add(dayUsage);
            }
        }
        
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            UsageListSum += UsageList.Sum();
            DaysListSum += DaysList.Sum();
            AverageDailyUsage = UsageListSum / DaysListSum;

            foreach (var dayUsage in this.DayUsageList)
            {
                statistics.AddDayUsage(dayUsage);
                MinDayUsageInvoiceNumber += DayUsageList.IndexOf(statistics.Min) + 1;
                MaxDayUsageInvoiceNumber += DayUsageList.IndexOf(statistics.Max) + 1;
            }
            return statistics;
        }
    }
}