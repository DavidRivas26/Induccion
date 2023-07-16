using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.Operations;
using LogicLayer;

namespace Administrative.Controllers
{
    public class UserController : BaseController
    {
        public UserController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            _users = new Users_BLL(connection);
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Index()
        {
            if (Auth())
                return RedirectToAction("Login");

            ViewBag.User = Session["User"];
            return View();
        }
        public RedirectToRouteResult LogOut()
        {
            Session["User"] = null;
            return RedirectToAction("Login");
        }
        public JsonResult UsersAdd(User user)
        {
            return Json(_users.Add(user), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UsersUpdate(User user)
        {
            return Json(_users.Update(user), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UsersValidate(User user)
        {
            return Json(Session["User"] = _users.Login(user), JsonRequestBehavior.AllowGet);
        }
    }
}