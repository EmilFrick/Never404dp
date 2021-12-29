namespace never_404.Repository
{
    public class UserRepository
    {
        private static UserRepository userRepo;

        private UserRepository()
        {

        }

        public static UserRepository GetRepository()
        {
            if (userRepo == null)
            {
                userRepo = new UserRepository();
            }
            return userRepo;
        }

        public static void CreateUser(User user)
        {
            BankDBContext db = new BankDBContext();
            db.User.Add(user);
            db.SaveChanges();
        }
        //public static User GenerateUser(string sSN, string firstName, string lastName, string pw)
        //{
        //    User user = new User();
        //    user.SSN = sSN;
        //    user.FirstName = firstName;
        //    user.LastName = lastName;
        //    user.Password = pw;

        //    return user;
        //}
    }
}
