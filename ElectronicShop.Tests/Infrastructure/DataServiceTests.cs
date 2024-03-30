using ElectronicShop.Infrastructure;

namespace ElectronicShop.Tests.Infrastructure
{
    public class DataServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WriteJson_WritesToFile()
        {
            //Arrange
            DataService<int> dataService = new DataService<int> { FileName = "TestFile.txt" };

            //Act
            dataService.WriteJson(256);

            //Assert
            Assert.IsTrue(File.Exists(dataService.FileName));

            File.Delete(dataService.FileName);
        }
    }
}