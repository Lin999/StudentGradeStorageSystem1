using GradeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeSystem.Data.Repositories
{
    public static class UserRepository
    {
        static List<User> users = new List<User>()
        {
            new User { Email = "abc@gmail.com", Roles = "Admin", Password = "abcadmin" },
            new User { Email = "xyz@gmail.com", Roles = "Student", Password = "xyzstudent" }
        };

        public static User GetUserDetails(User user)
        {
            return users.Where(u => u.Email.ToLower() == user.Email.ToLower() && u.Password == user.Password).FirstOrDefault();
        }

    }
}
