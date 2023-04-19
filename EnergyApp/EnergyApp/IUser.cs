namespace EnergyApp
{
    public interface IUser
    {

        string UserId { get; }

        float InvoiceCountAsFloat { get; }

        float UsageListSum { get; }

        float DaysListSum { get; }

        int MinDayUsageInvoiceNumber { get; }

        int MaxDayUsageInvoiceNumber { get; }

        float AverageDailyUsage { get; }

        List<float> UsageList { get; }

        List<float> DaysList { get; }

        List<float> DayUsageList { get; }

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

        Statistics GetStatistics();
    }
}