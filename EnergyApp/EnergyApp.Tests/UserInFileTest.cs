namespace EnergyApp.Tests
{
    public class Tests
    {
        
        [Test]
        public void AddUsageMethodCheckInFile()
        {
            //arrange
            var user = new UserInFile("EdytaM");
            user.AddUsage(100);
            user.AddUsage(200);
            user.AddUsage(240);

            //act
            var result = user.usageListSum;

            //assert
            Assert.AreEqual(540, result);
        }

        [Test]
        public void AddDaysMethodCheckInFile()
        {
            //arrange
            var user = new UserInFile("EdytaM");
            user.AddDays(10);
            user.AddDays(50);
            user.AddDays(40);

            //act
            var result = user.daysListSum;

            //assert
            Assert.AreEqual(100, result);
        }

        [Test]
        public void AddDayUsageMethodCheckInFile()
        {
            //arrange
            var user = new UserInFile("EdytaM");
            user.invoiceCountAsFloat = 3;
            user.AddUsage(100);
            user.AddUsage(200);
            user.AddUsage(240);
            user.AddDays(10);
            user.AddDays(50);
            user.AddDays(40);
            user.AddDayUsage();

            //act
            var result1 = user.dayUsageList[0];
            var result2 = user.dayUsageList[1];
            var result3 = user.dayUsageList[2];

            //assert
            Assert.AreEqual(10, result1);
            Assert.AreEqual(4, result2);
            Assert.AreEqual(6, result3);
        }

        [Test]
        public void GetStatisticsMethodCheckInFile()
        {
            //arrange
            var user = new UserInFile("EdytaM");
            user.invoiceCountAsFloat = 3;
            user.AddUsage(100);
            user.AddUsage(200);
            user.AddUsage(240);
            user.AddDays(10);
            user.AddDays(50);
            user.AddDays(40);
            user.AddDayUsage();

            //act
            var result = user.GetStatistics();
            var result1 = user.minDayUsageInvoiceNumber;
            var result2 = user.maxDayUsageInvoiceNumber;

            //assert
            Assert.AreEqual(4, result.Min);
            Assert.AreEqual(10, result.Max);
            Assert.AreEqual(2, result1);
            Assert.AreEqual(1, result2);
        }
    }
}
