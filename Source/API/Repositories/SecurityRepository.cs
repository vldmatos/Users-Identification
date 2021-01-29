using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Sercuity;

namespace API.Repositories
{
    public class SecurityRepository
    {
        private static readonly List<User> Users = new List<User>()
        {
            new User(){ Id = 1, Username = "Johnn", Password = "092813", Role = Roles.Manager },
            new User(){ Id = 2, Username = "Mark",  Password = "552341", Role = Roles.Employee },
            new User(){ Id = 3, Username = "Suee",  Password = "556891", Role = Roles.Employee }
        };

        public static User GetUser(string username, string password)
        {
            var user = Users.Where(user => user.Username.ToLower() == username.ToLower() && user.Password == password).FirstOrDefault();

            if (user is null)
                return null;

            return
            new User()
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role
            };
        }
    }
}