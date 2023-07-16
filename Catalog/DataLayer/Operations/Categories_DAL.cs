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
    public class Categories_DAL
    {

        private SqlConnection _connection;

        public Categories_DAL(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Add(Category category)
        {

            SqlCommand command = new SqlCommand("sp_create_category", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.Parameters.AddWithValue("@Status", category.Status);
            command.Parameters.AddWithValue("@Author", category.Author);
            command.Parameters.AddWithValue("@Date_Creation", DateTime.Now);
            return ExecuteCommand(command);

        }

        public bool Update(Category category)
        {

            SqlCommand command = new SqlCommand("sp_update_category", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Category", category.Id_Category);
            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.Parameters.AddWithValue("@Status", category.Status);
            command.Parameters.AddWithValue("@Author", category.Author);
            command.Parameters.AddWithValue("@Date_Update", DateTime.Now);

            return ExecuteCommand(command);

        }

        public bool Delete(int Id)
        {

            SqlCommand command = new SqlCommand("sp_delete_category", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Category", Id);

            return ExecuteCommand(command);

        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            SqlCommand command = new SqlCommand("sp_get_all_category", _connection);

            command.CommandType = CommandType.StoredProcedure;

            _connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(new Category
                {
                    Id_Category = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                    Name = reader.IsDBNull(1) ? "" : reader.GetString(1),
                    Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Status = reader.IsDBNull(3) ? false : reader.GetBoolean(3),
                    Author = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Date_Creation = reader.IsDBNull(5) ? "" : reader.GetDateTime(5).ToShortDateString(),
                    Date_Update = reader.IsDBNull(6) ? "" : reader.GetDateTime(6).ToShortDateString(),
                });
            }

            _connection.Close();

            return categories;
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
