using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.Operations;
using LogicLayer;

namespace Administrative.Controllers
{
    public class CategoryController : UserController
    {
        public CategoryController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            _categories = new Categories_BLL(connection);
        }

        public ActionResult CategoriesIndex()
        {
            if (Auth())
                return RedirectToAction("Login", "User");

            return View();
        }

        public JsonResult CategoriesList()
        {
            return Json(_categories.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesAdd(Category category)
        {
            return Json(_categories.Add(category, _user.Name), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesGetById(int Id)
        {
            return Json(_categories.GetById(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesUpdate(Category category)
        {
            return Json(_categories.Update(category, _user.Name), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesDelete(int Id)
        {
            return Json(_categories.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}