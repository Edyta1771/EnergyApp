using EnergyApp;

Console.WriteLine("\nWelcome to the ENERGYAPP program for home energy consumption analysis");
Console.WriteLine("=====================================================================\n");

string userId;

while (true)
{
    Console.Write("Please enter User ID: ");
    userId = Console.ReadLine();
    if (!string.IsNullOrEmpty(userId) && !userId.StartsWith(" "))
    {
        Console.WriteLine("Thank you");
        break;
    }
    else
    {
        Console.WriteLine("Invalid entry, please try again");
    }
}

var user = new UserInFile(userId);

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


user.UsageAdded += UserUsageAdded;
user.DaysAdded += UserDaysAdded;

void UserUsageAdded(object sender, EventArgs args)
{
    Console.WriteLine("New energy usage added");
}

void UserDaysAdded(object sender, EventArgs args)
{
    Console.WriteLine("New invoice days added");
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

Console.WriteLine("\n===============================================================");
Console.WriteLine();
Console.WriteLine($"Energy usage statistics for the user: {user.UserId}\n");
Console.WriteLine($"Number of invoices analyzed: {user.invoiceCountAsFloat}");
Console.WriteLine($"Overall usage for all invoices: {user.usageListSum:N2} kWh");
Console.WriteLine($"Number of days covered by all invoices: {user.daysListSum}");
Console.WriteLine($"Average daily usage for all invoices: {averageDailyUsage:N2} kWh");
Console.WriteLine($"Min daily usage recorded for the invoice number {user.minDayUsageInvoiceNumber}: {statistics.Min:N2} kWh");
Console.WriteLine($"Max daily usage recorded for the invoice number {user.maxDayUsageInvoiceNumber}: {statistics.Max:N2} kWh\n");
Console.WriteLine();
Console.WriteLine($"How would you rate the ENERGYAPP program on the scale of 1 to 5 ?");
string score = Console.ReadLine();
switch (score) 
{ 
    case "1": Console.WriteLine("We are very sorry, we will try to highly improve the program\nGOOD BYE\n");
        break;
    case "2": Console.WriteLine("We are very sorry, we will try to improve the program\nGOOD BYE\n");
        break;
    case "3": Console.WriteLine("Thank you for this rating, we will try to improve the program further\nGOOD BYE\n");
        break;
    case "4": Console.WriteLine("Thank you for this rating, we are still aiming to improve the program further\nGOOD BYE\n");
        break;
    case "5": Console.WriteLine("Thank you for this rating, we are very happy and still working to improve the program further\nGOOD BYE\n");
        break;
    default: Console.WriteLine("Invalid score. Thank you for using the ENERGYAPP program\nGOOD BYE\n");
        break;
}
Console.WriteLine("===============================================================");
