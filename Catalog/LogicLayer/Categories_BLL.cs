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
    public class Categories_BLL
    {
        private Categories_DAL _categories = new Categories_DAL();

        public bool addCategory(Category category, string Author)
        {
            category.Author = Author;
            return _categories.addCategory(category);
        }
        public bool updateCategory(Category category, string Author) 
        {
            category.Author = Author;
            return _categories.updateCategory(category);
        }
        public bool deleteCategory(int idCategory) 
        {
            return _categories.deleteCategory(idCategory);
        }
        public List<Category> getAllCategories()
        {
            return _categories.getAllCategories();
        }
        public Category getCategoryById(int idCategory)
        {
            return _categories.getCategoryById(idCategory);
        }
    }
}
