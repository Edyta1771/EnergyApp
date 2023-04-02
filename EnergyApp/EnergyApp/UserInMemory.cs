namespace EnergyApp
{
    public class UserInMemory : UserBase
    {
        public override event UsageAddedDelegate UsageAdded;

        public override event DaysAddedDelegate DaysAdded;

        public float invoiceCountAsFloat = 0;

        public float usageListSum = 0;

        public float daysListSum = 0;

        public int minDayUsageInvoiceNumber = 0;

        public int maxDayUsageInvoiceNumber = 0;

        private List<float> usageList = new List<float>();

        private List<float> daysList = new List<float>();

        public List<float> dayUsageList = new List<float>();

        public object statistics { get; set; }

        public UserInMemory(string userId)
            : base(userId)
        {
        }

        public override float InvoiceCount(string invoiceCount)
        {
            if (float.TryParse(invoiceCount, out float result) && result >= 1 && result <= 12)
            {
                Console.WriteLine("Thank you");
                this.invoiceCountAsFloat += result;
            }
            else
            {
                throw new Exception("Wrong number given, please try again");
            }
            return result;
        }

        public override void AddUsage(float usage)
        {
            if (usage >= 0)
            {
                this.usageList.Add(usage);
                usageListSum += usage;

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
                this.daysList.Add(days);
                daysListSum += days;

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
            for (int i = 0; i < invoiceCountAsFloat; i++)
            {
                var dayUsage = this.usageList[i] / this.daysList[i];
                this.dayUsageList.Add(dayUsage);
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var dayUsage in this.dayUsageList)
            {
                statistics.AddDayUsage(dayUsage);
                this.minDayUsageInvoiceNumber = dayUsageList.IndexOf(statistics.Min) + 1;
                this.maxDayUsageInvoiceNumber = dayUsageList.IndexOf(statistics.Max) + 1;
            }
            return statistics;
        }
    }
}