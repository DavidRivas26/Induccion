using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Operations
{
    public class Users_DAL
    {

        private SqlConnection _connection;
        public Users_DAL(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Add(User user)
        {

            SqlCommand command = new SqlCommand("sp_create_user", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Address", user.Address);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            return ExecuteCommand(command);

        }

        public bool Update(User user)
        {

            SqlCommand command = new SqlCommand("sp_update_user", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_User", user.Id_User);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Address", user.Address);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);

            return ExecuteCommand(command);

        }

        public User Login(User user)
        {

            SqlCommand command = new SqlCommand("sp_validate_user", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);

            _connection.Open();

            var reader = command.ExecuteReader();
            
            if (reader.Read())
            {
                user = new User
                {
                    Id_User = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                    Name = reader.IsDBNull(1) ? "" : reader.GetString(1),
                    LastName = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Address = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Phone = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Email = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Password = reader.IsDBNull(6) ? "" : reader.GetString(6),
                };
            }

            _connection.Close();

            return user;
        }

        public bool ExecuteCommand(SqlCommand command)
        {
            try
            {

                _connection.Open();

                command.ExecuteNonQuery();

                _connection.Close();

                return true;

            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
