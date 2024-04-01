using System.Text.Json;

namespace ElectronicShop.Infrastructure
{
    public class DataService<T> : IDataService<T>
    {
        public required string FileName { get; set; }

        public void WriteJson(T data)
        {
            var serializedData = JsonSerializer.Serialize(data);
            File.WriteAllText(FileName, serializedData);
        }
    }
}
