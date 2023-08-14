using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Models;

namespace Administrative.Sessions
{
    public static class SessionExtensions
    {
        public static User loggedUser
        {
            get { return HttpContext.Current.Session["user"] as User; }
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        }

        public static bool Auth()
        {
            return loggedUser == null;
        }
    } 
}