namespace Aplikacja.TestProject
{
    public class Tests
    {
        
        [Test]
        public void WhenStringAdded_ShouldAddedPoints()
        {   
            // arrange
            var employee = new EmployeeMemory("Jan", "Nowak", "15-08-2001", "Mê¿czyzna");
            employee.AddGrade("38,75");

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(38, 75, statistics.Min);
            Assert.AreEqual(38, 75, statistics.Min);
            Assert.AreEqual(38, 75, statistics.Average);
            Assert.AreEqual('B', statistics.AverageLetter);
        }

        [Test]
        public void WhenCharAdded_ShouldAddedpoints()
        {
            // arrange
            var employee = new EmployeeMemory("Jan", "Nowak", "15-08-2001", "Mê¿czyzna");
            employee.AddGrade('A');

            // act
            var user = employee.GetStatistics();
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(50, statistics.Min);
            Assert.AreEqual(50, statistics.Min);
            Assert.AreEqual(50, statistics.Average);
            Assert.AreEqual('A', statistics.AverageLetter);
        }
        [Test]
        public void WhenForPointsAdded_ShouldReturnMinimumMaximumAverageAverageLetter()
        {
            // arrange
            var user = new EmployeeMemory("Jan", "Nowak", "15-08-2001", "Mê¿czyzna");
            user.AddGrade(5);
            user.AddGrade(10);
            user.AddGrade(20);
            user.AddGrade('B');

            // act
            var Statistics = user.GetStatistics();

            // assert
            Assert.AreEqual(5, Statistics.Min);
            Assert.AreEqual(40, Statistics.Max);
            Assert.AreEqual(18.75, Statistics.Average);
            Assert.AreEqual('E', Statistics.AverageLetter);
        }
    }
}