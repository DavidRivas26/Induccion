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
    public class Products_DAL
    {
        DBConnection dbConnection = new DBConnection();

        public bool addProduct(Product product)
        {

            SqlCommand command = new SqlCommand("sp_create_product", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Category_FK", product.Id_Category);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@Stock", product.Stock);
            command.Parameters.AddWithValue("@Detail", product.Detail);
            command.Parameters.AddWithValue("@Status", product.Status);
            command.Parameters.AddWithValue("@Author", product.Author);
            command.Parameters.AddWithValue("@Date_Creation", DateTime.Now);
            return executeCommand(command);

        }

        public bool updateProduct(Product product)
        {

            SqlCommand command = new SqlCommand("sp_update_product", dbConnection.getConnection());
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

            return executeCommand(command);

        }

        public bool updateProductDetail(Product product)
        {

            SqlCommand command = new SqlCommand("sp_update_product_detail", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Product", product.Id_Product);
            command.Parameters.AddWithValue("@Detail", product.Detail);
            command.Parameters.AddWithValue("@Date_Update", DateTime.Now);

            return executeCommand(command);
        }

        public bool deleteProduct(int idProduct)
        {

            SqlCommand command = new SqlCommand("sp_delete_product", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Product", idProduct);

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

        public List<Product> getAllProducts()
        {
            SqlCommand command = new SqlCommand("sp_get_all_product", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            return executeReader(command);
        }

        public List<Product> getProductByCategory(string category)
        {
            SqlCommand command = new SqlCommand("sp_get_product_by_category", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Category", category);

            return executeReader(command);
        }

        public List<Product> searchProductByName(string name)
        {
            SqlCommand command = new SqlCommand("sp_get_product_by_name", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", name);

            return executeReader(command);
        }

        public Product getProductById(int idProduct)
        {
            SqlCommand command = new SqlCommand("sp_get_product_by_id", dbConnection.getConnection());
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Id_Product", idProduct);

            return executeReader(command)[0];
        }

        private List<Product> executeReader(SqlCommand command)
        {
            List<Product> products = new List<Product>();

            try
            {
                dbConnection.getConnection();

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
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dbConnection.closeConnection();
            }

            return products;
        }
    }
}
