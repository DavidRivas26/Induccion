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
        private Categories_DAL _categories;
        public Categories_BLL(SqlConnection connection) 
        {
            _categories = new Categories_DAL(connection);
        }
        public bool Add(Category category, string Author)
        {
            category.Author = Author;
            return _categories.Add(category);
        }
        public bool Update(Category category, string Author) 
        {
            category.Author = Author;
            return _categories.Update(category);
        }
        public bool Delete(int Id) 
        {
            return _categories.Delete(Id);
        }
        public List<Category> GetAll()
        {
            return _categories.GetAll();
        }
        public Category GetById(int Id)
        {
            return _categories.GetAll().Find(x => x.Id_Category.Equals(Id));
;
        }
    }
}
