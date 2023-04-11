namespace EnergyApp
{
    public abstract class UserBase : IUser
    {
        public delegate void UsageAddedDelegate(object sender, EventArgs args);

        public abstract event UsageAddedDelegate UsageAdded;

        public delegate void DaysAddedDelegate(object sender, EventArgs args);

        public abstract event DaysAddedDelegate DaysAdded;

        public string UserId { get; private set; }

        public float InvoiceCountAsFloat { get; private set; }

        //public float UsageListSum { get; private set; }

        //public float DaysListSum { get; private set; }

        //public float AverageDailyUsage { get; private set; }

        //public int MinDayUsageInvoiceNumber { get; private set; }

        //public int MaxDayUsageInvoiceNumber { get; private set; }

        public UserBase(string userId)
        {
            this.UserId = userId;
            this.InvoiceCountAsFloat = 0;
        }

        public float InvoiceCount(string invoiceCount)
        {
            if (float.TryParse(invoiceCount, out float result) && result >= 1 && result <= 12)
            {
                Console.WriteLine("Thank you");
                this.InvoiceCountAsFloat += result;
            }
            else
            {
                throw new Exception("Wrong number given, please try again");
            }
            return result;
        }

        public abstract void AddUsage(float usage);

        public abstract void AddUsage(string usage);

        public abstract void AddUsage(double usage);

        public abstract void AddUsage(int usage);

        public abstract void AddDays(float days);

        public abstract void AddDays(string days);

        public abstract void AddDays(int days);

        public abstract void AddDays(double days);

        public abstract void AddDayUsage();

        public abstract Statistics GetStatistics();

    }
}