using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Operations;

namespace LogicLayer
{
    public class Users_BLL
    {
        private Users_DAL _users = new Users_DAL();

        public bool addUser(User user)
        {
            return _users.addUser(user);
        }
        public bool updateUser(User user)
        {
            return (_users.updateUser(user));
        }
        public User validateUser(User user)
        {
            return _users.validateUser(user);
        }
    }
}
