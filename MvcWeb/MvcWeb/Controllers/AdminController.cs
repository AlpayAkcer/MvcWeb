using FluentValidation.Results;
using MvcWeb.Models.Entity;
using MvcWeb.Models.Validations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeb.Controllers
{
    public class AdminController : Controller
    {
        Context db = new Context();

        public ActionResult Index()
        {
            var value = db.Admins.Include("UserSocials").ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valuerole = (from x in db.Roles
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleId.ToString()
                                              }).ToList();

            ViewBag.valuerolelist = valuerole;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            ValidationResult result = adminValidator.Validate(admin);

            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                    string yol = "/Uploads/user/" + dosyaAdi;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    admin.Picture = yol;
                }
                else
                {
                    admin.Picture = "/Uploads/user/user_image.jpg";
                }

                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valuerole = (from x in db.Roles
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleId.ToString()
                                              }).ToList();

            ViewBag.valuerolelist = valuerole;

            var value = db.Admins.Find(id);
            return View("EditAdmin", value);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin adm)
        {
            AdminValidator validations = new AdminValidator();
            ValidationResult result = validations.Validate(adm);

            var value = db.Admins.Find(adm.AdminId);

            if (result.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                    string yol = "/Uploads/user/" + dosyaAdi;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    adm.Picture = yol;
                }
                else
                {
                    adm.Picture = "/Uploads/no_image.png";
                }


                value.UserName = adm.UserName;
                value.Name = adm.Name;
                value.Surname = adm.Surname;
                value.Email = adm.Email;
                value.RoleId = adm.RoleId;
                value.Title = adm.Title;
                value.Picture = adm.Picture;
                value.Password = adm.Password;
                db.SaveChanges();
                TempData["AlertMessage"] = "Admin Başarıyla Güncellendi";
                //c.Entry(d).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}