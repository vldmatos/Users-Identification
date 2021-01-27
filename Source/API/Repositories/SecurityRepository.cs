using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Repositories
{
    public class SecurityRepository
    {
        private static readonly List<User> Users = new List<User>()
        {
            new User(){ Id = 1, Username = "Johnn", Password = "092813", Role = "manager"},
            new User(){ Id = 2, Username = "Mark",  Password = "552341", Role = "employee"},
            new User(){ Id = 3, Username = "Suee",  Password = "556891", Role = "employee"}
        };

        public static User GetUser(string username, string password)
        {
            return 
            Users.Where(user => user.Username.ToLower() == username.ToLower() && user.Password == password).FirstOrDefault();  
        }
    }
}