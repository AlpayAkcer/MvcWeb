using MvcWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcWeb.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();


        [HttpGet]
        public ActionResult AdminGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminGiris(Admin p)
        {
            var bilgi = c.Admins.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Email, false);
                Session["AdminUserName"] = bilgi.Email.ToString();
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("AdminGiris", "Login");
            }
        }
    }
}