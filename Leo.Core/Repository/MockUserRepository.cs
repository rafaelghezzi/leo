using Leo.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Leo.Core.Repository
{
    public class MockUserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "admin", Password = "admin", Role = "admin" });
            users.Add(new User { Id = 2, Username = "emp1", Password = "emp1", Role = "employee_1" });
            users.Add(new User { Id = 2, Username = "emp2", Password = "emp2", Role = "employee_2" });
            return users.Where(x => x.Username == username && x.Password == x.Password).FirstOrDefault();
        }
    }
}
