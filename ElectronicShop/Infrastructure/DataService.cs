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

        public T ReadJson()
        {
            bool fileExist = File.Exists(FileName);
            if (!fileExist)
            {
                return default;
            }
            string fileContent = File.ReadAllText(FileName);
            return JsonSerializer.Deserialize<T>(fileContent);
        }
    }
}
