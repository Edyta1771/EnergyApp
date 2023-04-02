namespace EnergyApp
{
    public class UserInFile : UserBase
    {
        public override event UsageAddedDelegate UsageAdded;

        public override event DaysAddedDelegate DaysAdded;

        public float invoiceCountAsFloat = 0;

        public float usageListSum = 0;

        public float daysListSum = 0;

        public int minDayUsageInvoiceNumber = 0;

        public int maxDayUsageInvoiceNumber = 0;

        private const string fileNameUsage = "usage.txt";

        private const string fileNameDays = "days.txt";

        private const string fileNameDayUsage = "dayusage.txt";

        public List<float> dayUsageList = new List<float>();

        public UserInFile(string userId)
            : base(userId)
        {
            File.Delete(fileNameUsage);
            File.Delete(fileNameDays);
            File.Delete(fileNameDayUsage);
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
                using (var writer = File.AppendText(fileNameUsage))
                {
                    writer.WriteLine(usage);
                }
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
                using (var writer = File.AppendText(fileNameDays))
                {
                    writer.WriteLine(days);
                }
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
            var usageList = new List<float>();
            var daysList = new List<float>();
            //var dayUsageList = new List<float>();

            if (File.Exists(fileNameUsage))
            {
                using (var reader = File.OpenText(fileNameUsage))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        float.TryParse(line, out float number);
                        if (number > 0)
                        {
                            usageList.Add(number);
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception($"File {fileNameUsage} doesn't exist");
            }

            if (File.Exists(fileNameDays))
            {
                using (var reader = File.OpenText(fileNameDays))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        float.TryParse(line, out float number);
                        if (number > 0)
                        {
                            daysList.Add(number);
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception($"File {fileNameDays} doesn't exist");
            }

            for (int i = 0; i < usageList.Count; i++)
            {
                var dayUsage = usageList[i] / daysList[i];
                this.dayUsageList.Add(dayUsage);


                if (dayUsage >= 0)
                {
                    using (var writer = File.AppendText(fileNameDayUsage))
                    {
                        writer.WriteLine(dayUsage);
                    }                 
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var dayUsageList = new List<float>();

            if (File.Exists(fileNameDayUsage))
            {
                using (var reader = File.OpenText(fileNameDayUsage))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        float.TryParse(line, out float number);
                        if (number > 0)
                        {
                            dayUsageList.Add(number);
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception($"File {fileNameDayUsage} doesn't exist");
            }

            var statistics = new Statistics();

            foreach (var dayUsage in dayUsageList)
            {
                statistics.AddDayUsage(dayUsage);
                this.minDayUsageInvoiceNumber = dayUsageList.IndexOf(statistics.Min) + 1;
                this.maxDayUsageInvoiceNumber = dayUsageList.IndexOf(statistics.Max) + 1;
            }
            return statistics;           
        }
    }
}
