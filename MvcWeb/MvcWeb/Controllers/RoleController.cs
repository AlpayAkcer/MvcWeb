using FluentValidation.Results;
using MvcWeb.Models;
using MvcWeb.Models.Entity;
using MvcWeb.Models.Validations;
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

        [HttpGet]
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Role role)
        {
            RoleValidator validator = new RoleValidator();
            ValidationResult result = validator.Validate(role);

            if (result.IsValid)
            {
                role.IsActive = true;
                db.Roles.Add(role);
                db.SaveChanges();
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

        [HttpGet]
        public ActionResult EditRole(int id)
        {
            var value = db.Roles.Find(id);
            return View("EditRole", value);
        }

        [HttpPost]
        public ActionResult EditRole(Role role)
        {
            RoleValidator validations = new RoleValidator();
            ValidationResult result = validations.Validate(role);

            if (result.IsValid)
            {
                var roller = db.Roles.Find(role.RoleId);
                roller.RoleName = role.RoleName;
                roller.Description = role.Description;
                db.SaveChanges();
                TempData["AlertMessage"] = "Role Güncellendi";
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

        public ActionResult DeleteRole(int id)
        {
            var valueId = db.Roles.Find(id);
            RoleValidator validator = new RoleValidator();
            ValidationResult result = validator.Validate(valueId);

            if (result.IsValid)
            {
                db.Roles.Remove(valueId);
                db.SaveChanges();
                TempData["AlertMessage"] = "Silme işlemi başarılı";
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

        public ActionResult DetailRole(int id)
        {
            var valueUser = db.Roles.Find(id);
            var value = db.Admins.Where(x => x.RoleId == id).ToList();
            ViewBag.valueName = valueUser.RoleName;

            AdminUserModel adm = new AdminUserModel();
            adm.Admins = db.Admins.Where(x => x.AdminId == id).ToList();
            adm.UserSocials = db.UserSocials.Where(x => x.AdminId == id).ToList();
            return View(adm);
        }
    }
}