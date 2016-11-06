using BigFamilyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BigFamilyWeb.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (model.Username != null && model.Password != null)
            {
                var log = model.Username;
                var pass = model.Password;

                if (System.Configuration.ConfigurationManager.AppSettings["AdminLogin"] == log &&
                    System.Configuration.ConfigurationManager.AppSettings["AdminPassword"] == pass)
                {
                    FormsAuthentication.RedirectFromLoginPage(log, false);
                }
            }
            return View();
        }
        
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}