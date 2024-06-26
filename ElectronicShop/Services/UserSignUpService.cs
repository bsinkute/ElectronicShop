﻿using ElectronicShop.Interfaces;
using ElectronicShop.Models;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace ElectronicShop.Services
{
    public class UserSignUpService : IUserSignUp
    {
        private readonly IUserService _userService;

        public UserSignUpService(IUserService userService)
        {
            _userService = userService;
        }

        public void SignUp()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User Sign Up:");
                Console.WriteLine("Nickname  can consist of:");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("only letters (both uppercase and lowercase), \ndigits, and underscores, \nand at least 6 but not more then 12 more characters:");
                Console.ResetColor();
                Console.WriteLine("Please enter a NICKNAME:");
                var nickName = Console.ReadLine();
                Console.WriteLine("Password Must contain at least: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("one number, \none symbol, \none uppercase and lowercase letters, \nand at least 8 or more characters:");
                Console.ResetColor();
                Console.WriteLine("Please enter a password:");
                var password = Console.ReadLine();
                if (CheckNickname(nickName) && CheckPassword(password))
                {

                    IPasswordService encodePsw = new PasswordService(password);
                    var encPsw = encodePsw.EncryptPassword();
                    _userService.SaveUser(nickName, encPsw);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User successfully created");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nickname or Pasword does not much minimum requirements. Try again");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }
            }

        }
        private bool CheckNickname(string nickname)
        {
            try
            {
                return Regex.IsMatch(nickname, @"^[a-zA-Z0-9_]{6,12}$");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Given arguments are not valid {ex.Message}");
                return false;
            }
            catch (RegexMatchTimeoutException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }
        private bool CheckPassword(string password)
        {
            try
            {
                return Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W)[\w\W]{8,}$");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Given arguments are not valid {ex.Message}");
                return false;
            }
            catch (RegexMatchTimeoutException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }
    }
}
