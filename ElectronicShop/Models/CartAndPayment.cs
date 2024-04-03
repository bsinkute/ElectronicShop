using ElectronicShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop.Models
{
    public class CartAndPayment
    {
        private DataService<Cart> _cartDataService;

        public CartAndPayment(string fileName)
        {
            _cartDataService = new DataService<Cart> { FileName = fileName };
        }

        public void SaveCart(Cart cart)
        {
            _cartDataService.WriteJson(cart);
        }

        public Cart GetCart()
        {
            return _cartDataService.ReadJson();
        }

        public void AddToCart(Product product, int quantity)
        {
            
            Cart cart = GetCart();

            
            if (cart == null)
            {
                cart = new Cart();
            }

            // Add the product to the cart
            cart.AddProduct(product, quantity);

            // Save the updated cart data
            SaveCart(cart);

            Console.WriteLine($"Added {quantity} {product.Name}(s) to the cart.");
        }

        public void Checkout(decimal amountPaid)
        {
            // Load the cart from file
            Cart cart = GetCart();

            // Check if cart is null or empty
            if (cart == null || cart.Products.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            // Calculate total amount to pay
            decimal totalAmount = cart.CalculateTotalAmount();

            // Check if the paid amount is sufficient
            if (amountPaid < totalAmount)
            {
                Console.WriteLine("Insufficient amount paid.");
                return;
            }

            // Calculate change
            decimal change = amountPaid - totalAmount;

            Console.WriteLine($"Paid {amountPaid:C}. Change: {change:C}");

            // Clear the cart after successful payment
            SaveCart(new Cart());
        }
    }
}
