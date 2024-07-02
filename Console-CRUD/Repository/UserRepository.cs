namespace Console_CRUD.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(User user) => _users.Add(user);

        public void UpdateUser(User updatedUser)
        {
            User existingUser = _users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.PhoneNumber = updatedUser.PhoneNumber;
            }
            else
            {
                Utility.PrintMessage("User Not Found");
            }
        }


        public void DeleteUser(User user) => _users.Remove(user);

        public User GetUserByID(int id) => _users.FirstOrDefault(u => u.Id == id);

        public List<User> GetAllUsers() => _users;

    }
}
