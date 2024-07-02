using System.Text.RegularExpressions;

namespace Console_CRUD
{
    public class Utility
    {

        public static void PrintMessage(string msg, bool isError = true)
        {
            if (isError)
                Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(msg);

            Console.ForegroundColor = ConsoleColor.White;
        }


        public static User GetUserDetailsFromInput()
        {
            string name = GetValidatedName();
            string email = GetValidatedEmail();
            string phoneNumber = GetValidatedPhoneNumber();

            return new User
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber
            };
        }

        private static string GetValidatedName()
        {
            while (true)
            {
                Console.Write("Enter Name (at least 3 characters): ");
                string name = Console.ReadLine();
                if (name.Length >= 3)
                {
                    return name;
                }
                PrintMessage("Name must be at least 3 characters long.");
            }
        }

        private static string GetValidatedEmail()
        {
            while (true)
            {
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();
                if (Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return email;
                }
                PrintMessage("Invalid email format.");
            }
        }

        private static string GetValidatedPhoneNumber()
        {
            while (true)
            {
                Console.Write("Enter Phone Number: ");
                string phoneNumber = Console.ReadLine();
                if (Regex.IsMatch(phoneNumber, @"^(010|011|012|015)\d{8}$"))
                {
                    return phoneNumber;
                }
                PrintMessage("Invalid phone number. Must start with 010, 011, 012, or 015 and be 11 digits long.");
            }
        }
        public static void PrintUserDetails(User user)
        {
            Console.WriteLine();
            Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Phone Number: {user.PhoneNumber}");
        }

        public static void PrintMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("""
                  ____                      _         ____ ____  _   _ ____  
                 / ___|___  _ __  ___  ___ | | ___   / ___|  _ \| | | |  _ \ 
                | |   / _ \| '_ \/ __|/ _ \| |/ _ \ | |   | |_) | | | | | | |
                | |__| (_) | | | \__ \ (_) | |  __/ | |___|  _ <| |_| | |_| |
                 \____\___/|_| |_|___/\___/|_|\___|  \____|_| \_\\___/|____/ 
                                                                             
                """);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1-Add User");
            Console.WriteLine("2-Update Data of User");
            Console.WriteLine("3-Delete User");
            Console.WriteLine("4-Print All User");
            Console.WriteLine("5-Exit");
            Console.Write("Enter your choice: ");
        }

        public static bool AskToContinue()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Do you want to perform another operation? (Y/N): ");
            char choice = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            return choice == 'y' || choice == (char)ConsoleKey.Enter;
        }
    }
}
