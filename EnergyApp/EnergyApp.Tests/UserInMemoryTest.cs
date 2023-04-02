namespace EnergyApp.Tests
{
    public class Tests1
    {
        [Test]
        public void AverageUsageCalculationCheck()
        {
            //arrange
            float usage1 = 100;
            float usage2 = 200;
            int days1 = 10;
            int days2 = 50;

            //act
            var usageSum = usage1 + usage2;
            var daysSum = days1 + days2;
            var averageUsage = usageSum / daysSum;

            //assert
            Assert.AreEqual(5, averageUsage);
        }

        [Test]
        public void AddUsageMethodCheckInMemory()
        {
            //arrange
            var user = new UserInMemory("EdytaM");
            user.AddUsage(100);
            user.AddUsage(200);
            user.AddUsage(240);

            //act
            var result = user.usageListSum;

            //assert
            Assert.AreEqual(540, result);
        }

        [Test]
        public void AddDaysMethodCheckInMemory()
        {
            //arrange
            var user = new UserInMemory("EdytaM");
            user.AddDays(10);
            user.AddDays(50);
            user.AddDays(40);

            //act
            var result = user.daysListSum;

            //assert
            Assert.AreEqual(100, result);
        }

        [Test]
        public void AddDayUsageMethodCheckInMemory()
        {
            //arrange
            var user = new UserInMemory("EdytaM");
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
        public void GetStatisticsMethodCheckInMemory()
        {
            //arrange
            var user = new UserInMemory("EdytaM");
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