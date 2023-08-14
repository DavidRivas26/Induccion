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
        private Products_DAL _products = new Products_DAL();

        public bool addProduct(Product product, string Author = "")
        {
            product.Author = Author;
            return _products.addProduct(product);
        }
        public bool updateProduct(Product product, string Author = "")
        {
            product.Author = Author;
            return _products.updateProduct(product);
        }
        public bool updateProductDetail(Product product)
        {
            return _products.updateProductDetail(product);
        }
        public bool deleteProduct(int idProduct)
        {
            return _products.deleteProduct(idProduct);
        }
        public List<Product> getAllProducts()
        {
            return _products.getAllProducts();
        }
        public List<Product> getProductByCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
                category = string.Empty;

            return _products.getProductByCategory(category);
        }
        public List<Product> searchProductByName(string name)
        {
            if(string.IsNullOrEmpty(name))
                name = string.Empty;

            return _products.searchProductByName(name);
        }
        public Product getProductById(int idProduct)
        {
            return _products.getProductById(idProduct);
        }
    }
}
