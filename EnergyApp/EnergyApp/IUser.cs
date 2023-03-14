namespace EnergyApp
{
    public interface IUser
    {
        string UserId { get; }

        float InvoiceCount(string invoiceCount);

        void AddUsage(float usage);

        void AddUsage(string usage);

        void AddUsage(double usage);

        void AddUsage(int usage);

        void AddDays(float days);

        void AddDays(string days);

        void AddDays(int days);

        void AddDays(double days);

        void AddDayUsage();

        //delegate void UsageAddedDelegate(object sender, EventArgs args);

        //event UsageAddedDelegate UsageAdded;

        Statistics GetStatistics();
    }
}