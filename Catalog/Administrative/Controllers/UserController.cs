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
    public class UserController : Controller
    {
        Users_BLL _users = new Users_BLL();
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
            if (Sessions.SessionExtensions.Auth())
                return RedirectToAction("Login");

            User user = Sessions.SessionExtensions.loggedUser;
            return View(user);
        }
        public RedirectToRouteResult LogOut()
        {
            Sessions.SessionExtensions.loggedUser = null;
            return RedirectToAction("Login");
        }
        public JsonResult UsersAdd(User user)
        {
            return Json(_users.addUser(user) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UsersUpdate(User user)
        {
            return Json(_users.updateUser(user) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UsersValidate(User user)
        {
            return Json(Sessions.SessionExtensions.loggedUser = _users.validateUser(user), JsonRequestBehavior.AllowGet);
        }
    }
}