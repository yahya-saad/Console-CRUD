namespace Console_CRUD.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        User GetUserByID(int id);
        List<User> GetAllUsers();
    }
}
