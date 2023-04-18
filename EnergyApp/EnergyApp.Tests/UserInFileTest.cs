namespace EnergyApp.Tests
{
    public class Tests
    {
 
        [Test]
        public void AddingMethodsCheckInFile()
        {
            //arrange
            var user = new UserInFile("EdytaM");
            user.AddUsage(100);
            user.AddUsage(200);
            user.AddUsage(240);
            user.AddDays(10);
            user.AddDays(50);
            user.AddDays(40);
            user.AddDayUsage();

            //act
            var resultUsage = user.UsageList.Sum();
            var resultDays = user.DaysList.Sum();
            var result1 = user.DayUsageList[0];
            var result2 = user.DayUsageList[1];
            var result3 = user.DayUsageList[2];

            //assert
            Assert.AreEqual(540, resultUsage);
            Assert.AreEqual(100, resultDays);
            Assert.AreEqual(10, result1);
            Assert.AreEqual(4, result2);
            Assert.AreEqual(6, result3);
        }

        [Test]
        public void GetStatisticsMethodCheckInFile()
        {
            //arrange
            var user = new UserInFile("EdytaM");
            user.AddUsage(100);
            user.AddUsage(200);
            user.AddUsage(240);
            user.AddDays(10);
            user.AddDays(50);
            user.AddDays(40);
            user.AddDayUsage();

            //act
            var result = user.GetStatistics();
            var result1 = user.MinDayUsageInvoiceNumber;
            var result2 = user.MaxDayUsageInvoiceNumber;

            //assert
            Assert.AreEqual(4, result.Min);
            Assert.AreEqual(10, result.Max);
            Assert.AreEqual(2, result1);
            Assert.AreEqual(1, result2);
        }
    }
}
