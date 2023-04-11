namespace EnergyApp.Tests
{
    public class Tests1
    {
        [Test]
        public void AddUsageMethodCheckInMemory()
        {
            //arrange
            var user = new UserInMemory("EdytaM");
            user.AddUsage(100);
            user.AddUsage(200);
            user.AddUsage(240);

            //act
            var result = user.UsageList.Sum();
            
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
            var result = user.DaysList.Sum();

            //assert
            Assert.AreEqual(100, result);
        }

        [Test]
        public void AddDayUsageMethodCheckInMemory()
        {
            //arrange
            var user = new UserInMemory("EdytaM");
            user.AddUsage(100);
            user.AddUsage(200);
            user.AddUsage(240);
            user.AddDays(10);
            user.AddDays(50);
            user.AddDays(40);
            user.AddDayUsage();

            //act
            var result1 = user.DayUsageList[0];
            var result2 = user.DayUsageList[1];
            var result3 = user.DayUsageList[2];

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