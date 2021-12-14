using MvcWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    public class ContentController : Controller
    {
        Context db = new Context();
        // GET: Content

        public ActionResult Index()
        {
            var list = db.Contents.Where(x => x.IsActive == true).ToList();
            return View(list);
        }
    }
}