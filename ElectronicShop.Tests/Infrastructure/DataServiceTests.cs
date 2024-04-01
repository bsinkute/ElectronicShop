using ElectronicShop.Infrastructure;
using System.Text.Json;

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
            DataService<int> dataService = new DataService<int> { FileName = "TestFile.json" };

            //Act
            dataService.WriteJson(256);

            //Assert
            Assert.IsTrue(File.Exists(dataService.FileName));

            File.Delete(dataService.FileName);
        }

        [Test]
        public void WriteJson_WritesJson()
        {
            //Arrange
            DataService<int> dataService = new DataService<int> { FileName = "TestFile.json" };
            int actualNumber = 256;

            //Act
            dataService.WriteJson(actualNumber);
            string fileText = File.ReadAllText(dataService.FileName);
            var deserialized = JsonSerializer.Deserialize<int>(fileText);

            //Assert
            Assert.AreEqual(actualNumber, deserialized);

            File.Delete(dataService.FileName);
        }
    }
}