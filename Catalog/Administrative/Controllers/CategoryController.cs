using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.Operations;
using LogicLayer;

namespace Administrative.Controllers
{
    public class CategoryController : UserController
    {
        private Categories_BLL _categories = new Categories_BLL();
        public ActionResult CategoriesIndex()
        {
            if (Sessions.SessionExtensions.Auth())
                return RedirectToAction("Login", "User");

            return View();
        }

        public JsonResult CategoriesList()
        {
            return Json(_categories.getAllCategories(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesAdd(Category category)
        {
            return Json(_categories.addCategory(category, Sessions.SessionExtensions.loggedUser.Name) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesGetById(int Id)
        {
            return Json(_categories.getCategoryById(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesUpdate(Category category)
        {
            return Json(_categories.updateCategory(category, Sessions.SessionExtensions.loggedUser.Name) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesDelete(int Id)
        {
            return Json(_categories.deleteCategory(Id) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
    }
}