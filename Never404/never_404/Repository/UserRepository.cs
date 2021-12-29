using System.Collections.Generic;
using System.Linq;

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

        public void CreateUser(User user)
        {
            BankDBContext db = new BankDBContext();
            db.User.Add(user);
            db.SaveChanges();
        }
        public User GenerateUser(string sSN, string firstName, string lastName, string pw, string membershipType)
        {
            User user = new User();
            user.SSN = sSN;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Password = pw;
            user.MembershipType = membershipType;

            return user;
        }
        public List<string> GetMebershipType()
        {
            List<string> membershipType = new List<string>();
            BankDBContext db = new BankDBContext();
            var list = db.MembershipType.Where(x => x.MembershipTypeName != "Bank");
            foreach (var name in list)
            {
                membershipType.Add(name.MembershipTypeName);
            }
            return membershipType;
        }
    }
}
