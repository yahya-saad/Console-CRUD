namespace Console_CRUD.Models
{
    public class User
    {
        private static int _id = 0;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public User()
        {
            Id = ++_id;
        }
    }
}
