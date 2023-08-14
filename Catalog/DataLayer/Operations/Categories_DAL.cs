using DataLayer.DB;
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
        DBConnection dbConnection = new DBConnection();

        public bool addCategory(Category category)
        {

            SqlCommand command = new SqlCommand("sp_create_category", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.Parameters.AddWithValue("@Status", category.Status);
            command.Parameters.AddWithValue("@Author", category.Author);
            command.Parameters.AddWithValue("@Date_Creation", DateTime.Now);
            return executeCommand(command);

        }

        public bool updateCategory(Category category)
        {

            SqlCommand command = new SqlCommand("sp_update_category", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Category", category.Id_Category);
            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Description", category.Description);
            command.Parameters.AddWithValue("@Status", category.Status);
            command.Parameters.AddWithValue("@Author", category.Author);
            command.Parameters.AddWithValue("@Date_Update", DateTime.Now);

            return executeCommand(command);

        }

        public bool deleteCategory(int idCategory)
        {

            SqlCommand command = new SqlCommand("sp_delete_category", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Category", idCategory);

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

        public Category getCategoryById(int idCategory)
        {
            SqlCommand command = new SqlCommand("sp_get_category_by_id", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Category", idCategory);

            return executeReader(command)[0];
        }

        public List<Category> getAllCategories()
        {
            SqlCommand command = new SqlCommand("sp_get_all_category", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            return executeReader(command);
        }

        private List<Category> executeReader(SqlCommand command)
        {
            List<Category> categories = new List<Category>();

            try
            {
                dbConnection.getConnection();

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


            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbConnection.closeConnection();
            }

            return categories;
        }
    }
}
