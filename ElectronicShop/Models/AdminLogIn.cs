namespace ElectronicShop.Models
{
    public class AdminLogin
    {
        public void AdminLogIn()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Admin login: ");
                Console.WriteLine("Please enter your password:");
                var adminPassword = Console.ReadLine();

                if (adminPassword == "admin159")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You loged as ADMIN successfully");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong password");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press ENTER");
                    Console.ResetColor();
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
