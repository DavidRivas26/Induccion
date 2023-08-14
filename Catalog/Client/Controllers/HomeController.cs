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
        private Products_BLL _products = new Products_BLL();
        private Categories_BLL _categories = new Categories_BLL();
        public ActionResult Index()
        {
            ViewBag.categories = _categories.getAllCategories();
            return View();
        }
        public JsonResult List()
        {
            return Json(_products.getAllProducts(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListByCategory(string Id)
        {
            return Json(_products.getProductByCategory(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchProductList(string Id)
        {
            return Json(_products.searchProductByName(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateDetail(Product product)
        {
            return Json(_products.updateProductDetail(product), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetById(int Id)
        {
            return Json(_products.getProductById(Id), JsonRequestBehavior.AllowGet);
        }
    }
}