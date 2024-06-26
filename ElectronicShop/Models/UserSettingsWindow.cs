﻿namespace ElectronicShop.Models
{
    internal class UserSettingsWindow
    {
        public void LoadUserSettingsWindow(out int userSettingsSelection)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User Settings:");
                Console.WriteLine("1. Balance Overwiew \n2. Add Balance");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter number from 1 to 2: ");
                Console.ResetColor();
                bool isCorectSelection = int.TryParse(Console.ReadLine(), out userSettingsSelection);
                if (!isCorectSelection || userSettingsSelection < 1 || userSettingsSelection > 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Next time enter number from 1 to 2");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
                else break;
            }
        }
    }
}
