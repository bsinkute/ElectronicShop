namespace ElectronicShop.Infrastructure
{
    public class DataService<T> : IDataService<T>
    {
        public required string FileName { get; set; }

        public void WriteJson(T data)
        {
            File.WriteAllText(FileName, "laba diena");
        }
    }
}
