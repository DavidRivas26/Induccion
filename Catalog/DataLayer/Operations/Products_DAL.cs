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
    public class Products_DAL
    {

        private SqlConnection _connection;

        public Products_DAL(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Add(Product product)
        {

            SqlCommand command = new SqlCommand("sp_create_product", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Category_FK", product.Id_Category);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Stock", product.Stock);
            command.Parameters.AddWithValue("@Detail", product.Detail);
            command.Parameters.AddWithValue("@Status", product.Status);
            command.Parameters.AddWithValue("@Author", product.Author);
            command.Parameters.AddWithValue("@Date_Creation", DateTime.Now);
            return ExecuteCommand(command);

        }

        public bool Update(Product product)
        {

            SqlCommand command = new SqlCommand("sp_update_product", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Product", product.Id_Product);
            command.Parameters.AddWithValue("@Id_Category_FK", product.Id_Category);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Stock", product.Stock);
            command.Parameters.AddWithValue("@Detail", product.Detail);
            command.Parameters.AddWithValue("@Status", product.Status);
            command.Parameters.AddWithValue("@Author", product.Author);
            command.Parameters.AddWithValue("@Date_Update", DateTime.Now);

            return ExecuteCommand(command);

        }

        public bool UpdateDetail(Product product)
        {

            SqlCommand command = new SqlCommand("sp_update_product_detail", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Product", product.Id_Product);
            command.Parameters.AddWithValue("@Detail", product.Detail);
            command.Parameters.AddWithValue("@Date_Update", DateTime.Now);

            return ExecuteCommand(command);
        }

        public bool Delete(int Id)
        {

            SqlCommand command = new SqlCommand("sp_delete_product", _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Product", Id);

            return ExecuteCommand(command);

        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            SqlCommand command = new SqlCommand("sp_get_all_product", _connection);

            command.CommandType = CommandType.StoredProcedure;

            _connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id_Product = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                    Id_Category = reader.IsDBNull(1) ? "" : reader.GetString(1),
                    Name = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Description = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Stock = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                    Detail = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Status = reader.IsDBNull(6) ? false : reader.GetBoolean(6),
                    Author = reader.IsDBNull(7) ? "" : reader.GetString(7),
                    Date_Creation = reader.IsDBNull(8) ? "" : reader.GetDateTime(8).ToShortDateString(),
                    Date_Update = reader.IsDBNull(9) ? "" : reader.GetDateTime(9).ToShortDateString(),
                });
            }

            _connection.Close();

            return products;
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
