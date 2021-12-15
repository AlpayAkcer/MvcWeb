using FluentValidation.Results;
using MvcWeb.Helper;
using MvcWeb.Models.Entity;
using MvcWeb.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MvcWeb.Helper.ImageUpload;

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

        [HttpGet]
        public ActionResult AddContent()
        {
            List<SelectListItem> listvalue = (from x in db.Headings.Where(x => x.IsActive == true)
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.HeadingId.ToString()
                                              }).ToList();

            ViewBag.value = listvalue;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContent(Content content)
        {
            ContentValidator contentValidator = new ContentValidator();
            ValidationResult result = contentValidator.Validate(content);

            if (result.IsValid)
            {
                foreach (string item in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[item] as HttpPostedFileBase;
                    if (file.ContentLength == 0)
                        continue;
                    if (file.ContentLength > 0)
                    {
                        ImageUpload imageUpload = new ImageUpload { Width = 500 };
                        ImageResult imageResult = imageUpload.RenameUploadFile(file);

                        if (imageResult.Success)
                        {
                            content.Picture = imageResult.ImageName;
                        }
                        else
                        {
                            ViewBag.Error = imageResult.ErrorMessage;
                        }
                    }
                }

                db.Contents.Add(content);
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

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditContent(int id)
        {
            List<SelectListItem> listvalue = (from x in db.Headings.Where(x => x.IsActive == true)
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.HeadingId.ToString()
                                              }).ToList();

            ViewBag.value = listvalue;

            var icerikbul = db.Contents.Find(id);
            return View("EditContent", icerikbul);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContent(Content p)
        {
            ContentValidator contentValidator = new ContentValidator();
            ValidationResult result = contentValidator.Validate(p);

            var value = db.Contents.Find(p.ContentId);

            if (result.IsValid)
            {
                foreach (string item in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[item] as HttpPostedFileBase;
                    if (file.ContentLength == 0)
                        continue;
                    if (file.ContentLength > 0)
                    {
                        ImageUpload imageUpload = new ImageUpload { Width = 500 };
                        ImageResult imageResult = imageUpload.RenameUploadFile(file);

                        if (imageResult.Success)
                        {
                            p.Picture = imageResult.ImageName;
                        }
                        else
                        {
                            ViewBag.Error = imageResult.ErrorMessage;
                        }
                    }
                }

                value.Name = p.Name;
                value.Description = p.Description;
                value.IsActive = true;
                db.SaveChanges();
                TempData["AlertMessage"] = "İçerik Başarıyla Güncellendi";

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult IsActive(int id)
        {
            var updatevalue = db.Contents.Find(id);
            if (updatevalue.IsActive == true)
            {
                updatevalue.IsActive = false;
            }
            else
            {
                updatevalue.IsActive = true;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContent(int id)
        {
            var deletevalue = db.Contents.Find(id);
            deletevalue.IsActive = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}