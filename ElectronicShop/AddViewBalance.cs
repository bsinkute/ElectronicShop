using ElectronicShop.Infrastructure;
using ElectronicShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop
{
    public class AddViewBalance
    {
        private DataService<Customer> _customerDataService;

        public  AddViewBalance(string fileName)
        {
             _customerDataService = new DataService<Customer> { FileName = fileName };
         
        }

        public void SaveCustomer(Customer customer)
        {
            _customerDataService.WriteJson(customer);
        }

        public Customer GetCustomer()
        {
            return _customerDataService.ReadJson();
        }

        public void AddBalance(decimal amountToAdd)
        {
            // Load the customer from file
            Customer customer = GetCustomer();

            // Check if customer is null or not
            if (customer == null)
            {
                Console.WriteLine("Customer data not found.");
                return;
            }

            // Add the amount to the balance
            customer.Balance += amountToAdd;

            // Save the updated customer data
            SaveCustomer(customer);

            Console.WriteLine($"Added {amountToAdd:C} to customer's balance. New balance: {customer.Balance:C}");
        }
    }
}