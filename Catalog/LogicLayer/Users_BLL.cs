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
        private Users_DAL _users;
        public Users_BLL(SqlConnection connection)
        {
            _users = new Users_DAL(connection);
        }
        public bool Add(User user)
        {
            return _users.Add(user);
        }
        public bool Update(User user)
        {
            return (_users.Update(user));
        }
        public User Login(User user)
        {
            return _users.Login(user);
        }
    }
}
