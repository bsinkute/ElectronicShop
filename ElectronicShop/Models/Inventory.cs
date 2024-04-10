using System.Text;

namespace ElectronicShop.Models
{
    public class Inventory
    {
        public List<Item> Items { get; set; } = [];

        public void AddItem(string name, string description, decimal price, int quantity)
        {
            int id = Items.Any() ? Items.Max(item => item.Id) + 1 : 1;
            Item newItem = new Item
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                Quantity = quantity
            };
            Items.Add(newItem);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in Items)
            {
                stringBuilder.AppendLine(item.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
