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
    public class Products_BLL
    {
        private Products_DAL _products;
        public Products_BLL(SqlConnection connection) 
        {
            _products = new Products_DAL(connection);
        }
        public bool Add(Product product, string Author = "")
        {
            product.Author = Author;
            return _products.Add(product);
        }
        public bool Update(Product product, string Author = "")
        {
            product.Author = Author;
            return _products.Update(product);
        }
        public bool UpdateDetail(Product product)
        {
            return _products.UpdateDetail(product);
        }
        public bool Delete(int Id)
        {
            return _products.Delete(Id);
        }
        public List<Product> GetAll()
        {
            return _products.GetAll();
        }
        public List<Product> GetAllByCategory(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                Id = string.Empty;

            return _products.GetAll().Where(x => x.Id_Category == Id).ToList();
        }
        public List<Product> GetAllBySearch(string Id)
        {
            if(string.IsNullOrEmpty(Id))
                Id = string.Empty;

            return _products.GetAll().Where(x => x.Name.Contains(Id)).ToList();
        }
        public Product GetById(int Id)
        {
            return _products.GetAll().Find(x => x.Id_Product.Equals(Id));
        }
    }
}
