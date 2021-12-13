using MvcWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        Context db = new Context();
        // GET: Role


        public ActionResult Index()
        {
            var rolelist = db.Roles.ToList();
            return View(rolelist);
        }
    }
}