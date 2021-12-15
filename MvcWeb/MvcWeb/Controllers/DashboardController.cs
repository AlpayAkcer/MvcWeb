using MvcWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcWeb.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        Context db = new Context();
        // GET: Dashboard

        public ActionResult Index()
        {
            var headinglist = db.Headings.Count();
            ViewBag.HeadingCount = headinglist;
            return View();
        }

        public PartialViewResult AdminMenuLeftSidePartial()
        {
            return PartialView();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminGiris", "Login");
        }
    }
}