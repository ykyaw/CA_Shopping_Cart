using APIGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public class Users
    {
        private Dictionary<string, User> users =
            new Dictionary<string, User>();

        public User GetUser(string username)
        {
            User user;

            users.TryGetValue(username, out user);
            return user;
        }
    }
}
