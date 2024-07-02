namespace Console_CRUD.Services
{
    public class UserManagementService
    {
        private readonly IUserRepository _userRepository;

        public UserManagementService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser()
        {
            Console.WriteLine("============================Add User================================");
            User newUser = Utility.GetUserDetailsFromInput();
            _userRepository.AddUser(newUser);
            Utility.PrintUserDetails(newUser);
        }

        public void UpdateUser()
        {
            Console.WriteLine("============================Update User================================");
            Console.Write("Enter User Id you want to Edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                User existingUser = _userRepository.GetUserByID(id);
                if (existingUser != null)
                {
                    User updateUser = Utility.GetUserDetailsFromInput();

                    existingUser.Name = updateUser.Name;
                    existingUser.Email = updateUser.Email;
                    existingUser.PhoneNumber = updateUser.PhoneNumber;

                    _userRepository.UpdateUser(existingUser);
                    Utility.PrintUserDetails(existingUser);
                }
                else
                {
                    Utility.PrintMessage("User Not Found");
                }
            }
            else
            {
                Utility.PrintMessage("Invalid Id format");
            }
        }

        public void DeleteUser()
        {
            Console.WriteLine("============================Delete User================================");
            Console.Write("Enter User Id you want to Delete: ");
            int id = int.Parse(Console.ReadLine());
            User userToDelete = _userRepository.GetUserByID(id);
            if (userToDelete != null)
            {
                _userRepository.DeleteUser(userToDelete);
                Console.WriteLine($"Deleted user: {userToDelete.Name}");
            }
            else
                Utility.PrintMessage("User Not Found");

        }

        public void PrintAllUsers()
        {
            Console.WriteLine("============================Print All User================================");
            var users = _userRepository.GetAllUsers();

            if (users.Count == 0) { Utility.PrintMessage("No users to print."); return; }

            foreach (var user in users)
                Utility.PrintUserDetails(user);

        }

        public void GetUser()
        {
            Console.WriteLine("============================Get User================================");
            Console.Write("Enter User Id");
            int id = int.Parse(Console.ReadLine());

            User existingUser = _userRepository.GetUserByID(id);

            if (existingUser != null) Utility.PrintUserDetails(existingUser);
            else Utility.PrintMessage("User Not Found");

        }
    }
}
