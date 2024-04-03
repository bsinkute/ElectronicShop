using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop.Models
{
    public class Cart
    {
        public List<CartItem> Products { get; set; }

        public Cart()
        {
            Products = new List<CartItem>();
        }

        public void AddProduct(Product product, int quantity)
        {
            // Check if the product is already in the cart
            CartItem existingItem = Products.Find(item => item.Product.Id == product.Id);

            if (existingItem != null)
            {
                // If product exists, update quantity
                existingItem.Quantity += quantity;
            }
            else
            {
                // If product doesn't exist, add it to the cart
                Products.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (var item in Products)
            {
                totalAmount += item.Product.Price * item.Quantity;
            }
            return totalAmount;
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

