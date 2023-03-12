using EnergyApp;

Console.WriteLine("\nWelcome to the ENERGY program for home energy consumption analysis");
Console.WriteLine("==================================================================\n");

var user = new UserInMemory("EdytaM");
Console.WriteLine($"Please enter the energy consumption readings from the invoices for the user: {user.UserId} \n");
Console.WriteLine("Please state how many invoices will be analyzed \n" +
    "(The number should be in the range 1 - 12) \n");

while (true)
{
    Console.Write("The number of invoices is: ");
    var invoiceCount = Console.ReadLine();
    
    try
    {
        if (invoiceCount != null)
        {
            user.InvoiceCount(invoiceCount);
            break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception cought: {e.Message}");
    }
}


for (int i = 0; i < user.invoiceCountAsFloat; i++)
{
    var index = i + 1;
    Console.Write($"\nPrepare invoice number {index} ");

    while (true)
    {
        Console.Write("\nPlease enter the amount of energy used in kWh: ");
        var usage = Console.ReadLine();

        try
        {
            if (usage != null)
            {
                user.AddUsage(usage);
                break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception cought: {e.Message}");
        }
    }

    while (true)
    {
        Console.Write("Please enter the amount of days covered by this invoice: ");
        var days = Console.ReadLine();

        try
        {
            if (days != null)
            {
                user.AddDays(days);
                break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception cought: {e.Message}");
        }
    }
}

user.AddDayUsage();

var averageDailyUsage = user.usageListSum / user.daysListSum;

var statistics = user.GetStatistics();

Console.WriteLine("\n============================================================");
Console.WriteLine();
Console.WriteLine($"Energy usage statistics for the user: {user.UserId}\n");
Console.WriteLine($"Number of invoices analyzed: {user.invoiceCountAsFloat}");
Console.WriteLine($"Overall usage for all invoices analyzed: {user.usageListSum:N2} kWh");
Console.WriteLine($"Average daily usage for all invoices analyzed: {averageDailyUsage:N2} kWh");
Console.WriteLine($"Min daily usage for the invoice: {statistics.Min:N2} kWh");
Console.WriteLine($"Max daily usage for the invoice: {statistics.Max:N2} kWh\n");








//user.UsageAdded += UserUsageAdded;

//void UserUsageAdded(object sender, EventArgs args)
//{
//    Console.WriteLine("New energy usage added");
//}
