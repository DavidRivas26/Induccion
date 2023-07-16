using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.Operations;
using LogicLayer;

namespace Administrative.Controllers
{
    public class ProductController : UserController
    {

        public ProductController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            _products = new Products_BLL(connection);
            _categories = new Categories_BLL(connection);
        }

        public ActionResult ProductsIndex()
        {
            if (Auth())
                return RedirectToAction("Login", "Home");

            ViewBag.categories = _categories.GetAll();
            return View();
        }

        public JsonResult ProductsList()
        {
            return Json(_products.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsAdd(Product product)
        {
            return Json(_products.Add(product, _user.Name), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsGetById(int Id)
        {
            return Json(_products.GetById(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsUpdate(Product product)
        {
            return Json(_products.Update(product, _user.Name), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsDelete(int Id)
        {
            return Json(_products.Delete(Id), JsonRequestBehavior.AllowGet);
        }
    }
}