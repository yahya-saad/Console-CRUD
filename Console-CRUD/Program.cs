namespace Console_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserRepository userRepository = new UserRepository();
            UserManagementService userService = new UserManagementService(userRepository);

            while (true)
            {
                PrintMenu();
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            userService.AddUser();
                            break;
                        case 2:
                            userService.UpdateUser();
                            break;
                        case 3:
                            userService.DeleteUser();
                            break;
                        case 4:
                            userService.PrintAllUsers();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                            break;
                    }

                    if (!AskToContinue()) break;

                }
                else
                {
                    PrintMessage("Invalid input. Please enter a number.");
                }
            }
        }

    }
}
