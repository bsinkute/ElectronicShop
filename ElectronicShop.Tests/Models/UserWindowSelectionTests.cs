using ElectronicShop.Infrastructure;
using ElectronicShop.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop.Tests.Models
{
    internal class UserWindowSelectionTests
    {
        [Test]
        public void EditItem_UpdateJson()
        {
            //Arrange
            var itemId = 1;
            var newItemName = "New Item";
            var newDescription = "New Description";
            var newPrice = 20.0m;
            var newQuantity = 15;

            var inventory = new Inventory();
            inventory.AddItem("Test Item", "Test Description", 10.0m, 5);
            var dataService = new DataService<Inventory>();
            dataService.WriteJson(inventory);

            var adminWindowSelection = new AdminWindowSelection();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader($"{itemId}\n{newItemName}\n{newDescription}\n{newPrice}\n{newQuantity}\n"));


                //Act
                adminWindowSelection.EditItem();

                //Assert
                var expectedOutput = $"Editing item with ID {itemId}:" + Environment.NewLine +
                                     "Item updated successfully." + Environment.NewLine;
                Assert.Equal(expectedOutput, sw.ToString());
            }
            var updatedInventory = dataService.ReadJson();
            var editedItem = updatedInventory.Items.Find(item => item.Id == itemId);
            Assert.NotNull(editedItem);
            Assert.Equal(newItemName, editedItem.Name);
            Assert.Equal(newDescription, editedItem.Description);
            Assert.Equal(newPrice, editedItem.Price);
            Assert.Equal(newQuantity, editedItem.Quantity);
        }
    }
}
