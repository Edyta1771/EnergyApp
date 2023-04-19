using EnergyApp;

Console.WriteLine("\nWelcome to the ENERGYAPP program for home energy usage analysis");
Console.WriteLine("===============================================================\n");

Console.WriteLine("How would you like to store your energy readings from invoices?\n" +
                  "Press M or m - to store in the program memory \n" +
                  "Press F or f - to store in .txt file \n" +
                  "Press X or x = to exit the program \n");

while (true)
{
    string input = Console.ReadLine().ToUpper();

    switch (input)
    {
        case "M":
            Console.WriteLine("The data will be temporarily stored in the program memory");
            StoreReadingsInMemory();
            break;
        case "F":
            Console.WriteLine("The data will be stored in the .txt file");
            StoreReadingsInFile();
            break;
        case "X":
            Console.WriteLine("Good bye, press any key to finish the program\n");
            break;
        default:
            Console.WriteLine("Invalid key entry, please try again\n");
            continue;
    }
    break;
}

static void StoreReadingsInMemory()
{
    string userId;

    while (true)
    {
        Console.Write("Please enter your User ID: ");
        userId = Console.ReadLine();
        if (!string.IsNullOrEmpty(userId) && !userId.StartsWith(" "))
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid entry, please try again");
        }
    }

    var inMemoryUser = new UserInMemory(userId);
    inMemoryUser.UsageAdded += UserUsageAdded;
    inMemoryUser.DaysAdded += UserDaysAdded;
    InvoiceDataEntry(inMemoryUser);
    inMemoryUser.AddDayUsage();
    StatisticsPresentation(inMemoryUser);
}

static void StoreReadingsInFile()
{
    string userId;

    while (true)
    {
        Console.Write("Please enter your User ID: ");
        userId = Console.ReadLine();
        if (!string.IsNullOrEmpty(userId) && !userId.StartsWith(" "))
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid entry, please try again");
        }
    }
    var inFileUser = new UserInFile(userId);
    inFileUser.UsageAdded += UserUsageAdded;
    inFileUser.DaysAdded += UserDaysAdded;
    InvoiceDataEntry(inFileUser);
    inFileUser.AddDayUsage();
    StatisticsPresentation(inFileUser);
}

static void UserUsageAdded(object sender, EventArgs args)
{
    Console.WriteLine("New energy usage added");
}

static void UserDaysAdded(object sender, EventArgs args)
{
    Console.WriteLine("New invoice days added");
}

static void InvoiceDataEntry(UserBase user)
{
    Console.WriteLine("\nPlease type how many invoices will be analyzed \n" +
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

    for (int i = 0; i < user.InvoiceCountAsFloat; i++)
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
}

static void StatisticsPresentation(UserBase user)
{

    var statistics = user.GetStatistics();

    Console.WriteLine("\n==============================================================");
    Console.WriteLine();
    Console.WriteLine($"Energy usage statistics for the user: {user.UserId}\n");
    Console.WriteLine($"Number of invoices analyzed: {user.InvoiceCountAsFloat}");
    Console.WriteLine($"Overall usage for all invoices: {user.UsageListSum:N2} kWh");
    Console.WriteLine($"Number of days covered by all invoices: {user.DaysListSum}");
    Console.WriteLine($"Average daily usage for all invoices: {user.AverageDailyUsage:N2} kWh");
    Console.WriteLine($"Min daily usage recorded for the invoice number {user.MinDayUsageInvoiceNumber}: {statistics.Min:N2} kWh");
    Console.WriteLine($"Max daily usage recorded for the invoice number {user.MaxDayUsageInvoiceNumber}: {statistics.Max:N2} kWh");
    Console.WriteLine();
    Console.WriteLine("==============================================================\n");

}
