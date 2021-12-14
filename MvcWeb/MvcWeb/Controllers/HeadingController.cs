using FluentValidation.Results;
using MvcWeb.Helper;
using MvcWeb.Models.Entity;
using MvcWeb.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static MvcWeb.Helper.ImageUpload;

namespace MvcWeb.Controllers
{
    public class HeadingController : Controller
    {
        Context db = new Context();

        // GET: Heading
        public ActionResult Index()
        {
            var list = db.Headings.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHeading(Heading heading)
        {
            HeadingValidator headingValidator = new HeadingValidator();
            ValidationResult result = headingValidator.Validate(heading);

            if (result.IsValid)
            {

                db.Headings.Add(heading);
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
        public ActionResult EditHeading(int id)
        {
            var value = db.Headings.Find(id);
            return View("EditHeading", value);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHeading(Heading heading)
        {
            HeadingValidator headingValidator = new HeadingValidator();
            ValidationResult result = headingValidator.Validate(heading);

            var value = db.Headings.Find(heading.HeadingId);

            if (result.IsValid)
            {
                value.Name = heading.Name;
                value.IsActive = true;
                db.SaveChanges();
                TempData["AlertMessage"] = "Başlık Başarıyla Güncellendi";
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

        public ActionResult IsActiveChangingHeading(int id)
        {
            var deletevalue = db.Headings.Find(id);
            if (deletevalue.IsActive == true)
            {
                deletevalue.IsActive = false;
            }
            else
            {
                deletevalue.IsActive = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var deletevalue = db.Headings.Find(id);
            //db.Headings.Remove(deletevalue);
            deletevalue.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}