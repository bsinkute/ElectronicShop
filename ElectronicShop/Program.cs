using ElectronicShop.Models;

namespace ElectronicShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");

            // Create an instance of CustomerService with the filename "customers.json"
            AddViewBalance customerService = new AddViewBalance("customers.json");

            // Create a list to hold the customers
            List<Customer> customers = new List<Customer>
            {
                new Customer {  Name = "Alice",  Balance = 100.0m },
                new Customer { Name = "Bob", Balance = 150.0m },
                new Customer { Name = "Charlie",  Balance = 200.0m },
                new Customer {  Name = "David", Balance = 250.0m },
                new Customer { Name = "Eve",Balance = 300.0m }
            };

            //// Save each customer
            //foreach (var customer1 in customers)
            //{
            //    customerService.SaveCustomer(customer1);
            //    //Console.WriteLine($"Saved customer: {customer1.Name}");
            //}


            ////AddViewBalance customerService = new AddViewBalance("customer.json");

            //// Load customer data from file
            //Customer customer = customerService.GetCustomer();

            //// Check if customer data is loaded successfully
            //if (customer != null)
            //{
            //    // Display the current balance
            //    Console.WriteLine($"Current balance: {customer.Balance:C}");

            //    // Add money to the customer's balance
            //    decimal amountToAdd = 100.0m;
            //    customerService.AddBalance(amountToAdd);

            //    // Save the updated customer data to file
            //    customerService.SaveCustomer(customer);

            //    // Display the updated balance
            //    Console.WriteLine($"Updated balance: {customer.Balance:C}");
            //}
            //else
            //{
            //    Console.WriteLine("Customer data not found.");
            //}
            

        }
    }
}
