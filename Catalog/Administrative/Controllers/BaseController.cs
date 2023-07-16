using DataLayer.Operations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;
using DataLayer.Operations;
using LogicLayer;

namespace Administrative.Controllers
{
    public class BaseController : Controller
    {
        protected Products_BLL _products;
        protected Categories_BLL _categories;
        protected Users_BLL _users;
        public User _user = (User)System.Web.HttpContext.Current.Session["User"];

        public bool Auth()
        {
            return _user == null;
        }
    }
}