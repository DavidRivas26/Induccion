using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DB;

namespace DataLayer.Operations
{
    public class Users_DAL
    {
        DBConnection dbConnection = new DBConnection();

        public bool addUser(User user)
        {

            SqlCommand command = new SqlCommand("sp_create_user", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Address", user.Address);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            return executeCommand(command);

        }

        public bool updateUser(User user)
        {

            SqlCommand command = new SqlCommand("sp_update_user", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_User", user.Id_User);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Address", user.Address);
            command.Parameters.AddWithValue("@Phone", user.Phone);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);

            return executeCommand(command);

        }

        private bool executeCommand(SqlCommand command)
        {
            try
            {

                dbConnection.getConnection();

                command.ExecuteNonQuery();

                return true;

            }

            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                dbConnection.closeConnection();
            }
        }

        public User validateUser(User user)
        {

            SqlCommand command = new SqlCommand("sp_validate_user", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);

            return executeReader(command, user);
        }

        private User executeReader(SqlCommand command, User user)
        {
            try
            {
                dbConnection.getConnection();

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
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbConnection.closeConnection();
            }

            return user;
        }

    }
}
