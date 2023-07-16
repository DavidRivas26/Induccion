using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using LogicLayer;
using DataLayer.Models;
using DataLayer.Operations;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private Products_BLL _products;
        private Categories_BLL _categories;
        public HomeController() 
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            _products = new Products_BLL(connection);
            _categories = new Categories_BLL(connection);
        }
        public ActionResult Index()
        {
            ViewBag.categories = _categories.GetAll();
            return View();
        }
        public JsonResult List()
        {
            return Json(_products.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListByCategory(string Id)
        {
            return Json(_products.GetAllByCategory(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchProductList(string Id)
        {
            return Json(_products.GetAllBySearch(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateDetail(Product product)
        {
            return Json(_products.UpdateDetail(product), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetById(int Id)
        {
            return Json(_products.GetById(Id), JsonRequestBehavior.AllowGet);
        }
    }
}