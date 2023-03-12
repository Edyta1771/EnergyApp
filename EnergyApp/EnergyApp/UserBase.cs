namespace EnergyApp
{
    public abstract class UserBase : IUser
    {
        //public delegate void UsageAddedDelegate(object sender, EventArgs args);

        //public abstract event UsageAddedDelegate UsageAdded;

        public UserBase(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; private set; }

        public abstract float InvoiceCount(string invoiceCount);

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