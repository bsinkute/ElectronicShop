﻿using ElectronicShop.Infrastructure;
using ElectronicShop.Interfaces;
using ElectronicShop.Models;

namespace ElectronicShop.Services
{
    public class BalanceService : IBalanceService
    {
        private IDataService<UsersData> _userDataService;

        public BalanceService(IDataService<UsersData> userDataService)
        {
            _userDataService = userDataService;
        }

        public void SaveUser(User user)
        {
            var userData = _userDataService.ReadJson() ?? new UsersData();
            userData.UpdateUser(user);
            _userDataService.WriteJson(userData);
        }

        public void AddBalance(User user, decimal amountToAdd)
        {
            user.AddBalance(amountToAdd);
            SaveUser(user);

            Console.WriteLine($"Added {amountToAdd:N} € to customer's balance. New balance: {user.Balance:N} €");
        }
    }
}