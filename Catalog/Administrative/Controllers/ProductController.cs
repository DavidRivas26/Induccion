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
    public class ProductController : UserController
    {
        Products_BLL _products = new Products_BLL();
        Categories_BLL _categories = new Categories_BLL();
        public ActionResult ProductsIndex()
        {
            if (Sessions.SessionExtensions.Auth())
                return RedirectToAction("Login", "Home");

            List<Category> categories = _categories.getAllCategories();
            return View(categories);
        }

        public JsonResult ProductsList()
        {
            return Json(_products.getAllProducts(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsAdd(Product product)
        {
            return Json(_products.addProduct(product, Sessions.SessionExtensions.loggedUser.Name) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsGetById(int Id)
        {
            return Json(_products.getProductById(Id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsUpdate(Product product)
        {
            return Json(_products.updateProduct(product, Sessions.SessionExtensions.loggedUser.Name) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsDelete(int Id)
        {
            return Json(_products.deleteProduct(Id) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
    }
}